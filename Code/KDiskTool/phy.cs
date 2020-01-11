using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Threading;     //使用线程

namespace KDiskTool
{
    public partial class Form_KDisk
    {
		long fifo_top = 0;
		long fifo_bottom = 0;
        long fifo_top_cnt;
        long fifo_bottom_cnt;
		const int fifo_max = 32;
        const int dma_buffer_length = 1024 * 1024;
		byte[][] fifo_buffer = new byte[fifo_max][];
		bool read_is_end = false;

        BinaryReader br;
        Thread Thread_Read = null;
		Thread Thread_Write = null;

        long ignore_data_size;
		long loaded_data_size;

        long rd_img_block_cnt;
        long wr_disk_block_cnt;

        unsafe bool Func_Buffer_Is_All_Zero(byte *bp, int length)
        {
            if(length % 4 != 0)
            {
                MessageBox.Show("Write size error:{0}" + length.ToString(),
                    "Warning!", MessageBoxButtons.OK);

                return false;
            }

            uint* dwp = (uint*)bp;
            for(int v = 0; v < length / 4; v++)
            {
                if(dwp[v] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        unsafe public void Thread_Write_Entry()
		{
            ignore_data_size = 0;
            long written_data_size = 0;

			bool always_write_to_disk;
			always_write_to_disk = true;
			if(checkBox_Ignore.Checked == true)
			{
				always_write_to_disk = false;
			}

			while(true)
			{
                if(fifo_top > fifo_bottom)
                {
                    fifo_bottom_cnt = fifo_bottom % fifo_max;

                    long delta_size = loaded_data_size - written_data_size;
                    if(delta_size > dma_buffer_length)  //限定一次只能写入的数据量
                    {
                        delta_size = dma_buffer_length;
                    }

                    long written_lba = written_data_size / 512;
                    written_data_size += delta_size;
                    int sector_count = (int)(delta_size) / 512;
                    //Console.WriteLine("LBA:{0} Cnt:{1}", written_lba, sector_count);

                    /**********************计算是否写入START*********************/
                    bool need_write_disk = false;
                    if(always_write_to_disk == true)
                    {
                        need_write_disk = true;
                    }
                    else
                    {
#if true
                        fixed(byte *p = &fifo_buffer[fifo_bottom_cnt][0])
                        {
                            need_write_disk = !Func_Buffer_Is_All_Zero(p, fifo_buffer[fifo_bottom_cnt].Length);
                        }
                        
#else
                        for(int v = 0; v < fifo_buffer[fifo_bottom_cnt].Length; v++)
                        {
                            if(fifo_buffer[fifo_bottom_cnt][v] != 0)
                            {
                                need_write_disk = true;
                                break;
                            }
                        }
#endif
                    }

                    if(need_write_disk == true)
                    {
                        T.WritSector(fifo_buffer[fifo_bottom_cnt], written_lba, sector_count);//把数据写到disk上
                    }
                    else
                    {
                        ignore_data_size += fifo_buffer[fifo_bottom_cnt].Length;
                    }

                    fifo_bottom++;
                    /**********************计算是否写入END***********************/
                }
                else
                {
                    rd_img_block_cnt++;
                }

				if(read_is_end == true)
				{
					break;
				}
			}

            timer1.Enabled = false;
            last_loaded_size = 0;

            rd_img_block_cnt = 0;
            wr_disk_block_cnt = 0;

            speed_sum = 0;
            speed_cnt = 0;

            T.Close();

			Thread_Write.Abort("退出");
		}

        public void Thread_Read_Entry()                                     //线程入口
        {
            loaded_data_size = 0;            

            long read_out_size;

			System.DateTime start_time = new System.DateTime();
			start_time = System.DateTime.Now;

            timer1.Enabled = true;

            while(true)
            {
				if(fifo_top - fifo_bottom >= fifo_max)
				{
                    wr_disk_block_cnt++;
                    //Console.WriteLine("FIFO is full {0}:{1}", fifo_top, fifo_bottom);
                    continue;
				}
				/**********************从文件中读取START*********************/
                fifo_top_cnt = fifo_top % fifo_max;
                fifo_buffer[fifo_top_cnt] = br.ReadBytes(dma_buffer_length);
                read_out_size = fifo_buffer[fifo_top_cnt].Length;
                if(read_out_size == 0)
                {
                    break;
                }
                loaded_data_size += read_out_size;

                if(read_out_size % 512 != 0)							    //校验读取的数据是否正常
				{
                    MessageBox.Show("Data size error:{0}" + read_out_size.ToString(),
						"Warning!", MessageBoxButtons.OK);
				}

				fifo_top++;
				/**********************从文件中读取END***********************/
            }

            br.Close();

			System.DateTime end_time = new System.DateTime();
			end_time = System.DateTime.Now;

			MessageBox.Show("Start: " + start_time.ToString() + "\r\n" +
							"End: " + end_time.ToString() + "\r\n" +
							"Spend:" + (end_time - start_time).ToString(),
			"Finish!", MessageBoxButtons.OK);	

			read_is_end = true;

            Thread_Read.Abort("退出");     //结束线程
        }
    }

}
