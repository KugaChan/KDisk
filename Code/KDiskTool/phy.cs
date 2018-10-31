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
        const int dma_buff_length = 1024 * 1024;
        byte[] ReturnByte = new byte[dma_buff_length];
        long img_total_length;
        BinaryReader br;
        Thread BEThread;
        string fileName = null; //文件名

        bool console_show_progress = false;

        public void BEThreadEntry()                                         //线程入口
        {
			DialogResult result = DialogResult.Cancel;

			this.Invoke((EventHandler)(delegate
			{
				result = MessageBox.Show("start copy from [" + textBox_ImgPath.Text +
				"] to [" + comboBox_Disk.SelectedItem.ToString() + "] ?", "Start Copy?",
				 MessageBoxButtons.OKCancel, MessageBoxIcon.Question);	
			}));
			
			if(result == DialogResult.OK)
			{
				//确定按钮的方法
			}
			else
			{
				br.Close();
				return;//取消按钮的方法
			}

			System.DateTime start_time = new System.DateTime();
			start_time = System.DateTime.Now;

			long lba = 0;
            int read_cnt = 0;
            long loaded_data_size = 0;
            long ignore_data_size = 0;
			bool always_write_to_disk;

			always_write_to_disk = true;
			if(checkBox_Ignore.Checked == true)
			{
				always_write_to_disk = false;

                DialogResult res1 = DialogResult.Cancel;
                res1 = MessageBox.Show("Write to the disk without zero data", "Warning!",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(res1 != DialogResult.OK)
                {
                    return;
                }
			}

            while(true)
            {
				//从文件中读取出来
                ReturnByte = br.ReadBytes(dma_buff_length);
                if(ReturnByte.Length == 0)
                {
                    break;
                }

                loaded_data_size += ReturnByte.Length;

				int sector_count = ReturnByte.Length / 512;
				if(ReturnByte.Length % 512 != 0)
				{
					MessageBox.Show("Data size error:{0}" + ReturnByte.Length.ToString(),
						"Warning!", MessageBoxButtons.OK);
				}

				Console.WriteLine("LBA:{0} Cnt:{1}", lba, sector_count);

				if(T == null)
				{
					MessageBox.Show("Data size error:{0}" + ReturnByte.Length.ToString(),
						"Warning!", MessageBoxButtons.OK);				
				}

				bool need_write_disk = false;
				if(always_write_to_disk == true)
				{
					need_write_disk = true;
				}
                else
				{
					for(int v = 0; v < ReturnByte.Length; v++)
					{
						if(ReturnByte[v] != 0)
						{
							need_write_disk = true;
							break;
						}
					}				
				}

                if(need_write_disk == true)
                {
                    T.WritSector(ReturnByte, lba, sector_count);//把数据写到disk上
                }
                else
                {
                    ignore_data_size += ReturnByte.Length;
                }

				lba = loaded_data_size / 512;

                long percent_all = loaded_data_size * 100 / img_total_length;
                long percent_ignore = ignore_data_size * 100 / img_total_length;
                this.Invoke((EventHandler)(delegate
                {
					textBox_Progress.Text = loaded_data_size.ToString() + ":" + img_total_length.ToString() +
                        "(" + percent_all.ToString() + "%)";

                    if(need_write_disk == false)
                    {
                        textBox_Ignore.Text = ignore_data_size.ToString() + ":" + img_total_length.ToString() +
                            "(" + percent_ignore.ToString() + "%)";                   
                    }
                }));

                if(console_show_progress == true)
                {
                    long data_size_show_B = 0;
                    long data_size_show_KB = 0;
                    long data_size_show_MB = 0;
                    long data_size_show_GB = 0;
                    long data_size_left = 0;

                    long KB = 1024L;
                    long MB = 1024L * 1024L;
                    long GB = 1024L * 1024L * 1024L;
                    long TB = 1024L * 1024L * 1024L * 1024L;

                    data_size_left = loaded_data_size;
                    if(loaded_data_size < KB)
                    {
                        data_size_show_B = loaded_data_size;
                    }
                    else if(loaded_data_size < MB)
                    {
                        data_size_show_KB = data_size_left / KB;
                        data_size_left = data_size_left - data_size_show_KB * KB;

                        data_size_show_B = data_size_left;
                    }
                    else if(loaded_data_size < GB)
                    {
                        data_size_show_MB = data_size_left / MB;
                        data_size_left = data_size_left - data_size_show_MB * MB;

                        data_size_show_KB = data_size_left / KB;
                        data_size_left = data_size_left - data_size_show_KB * KB;

                        data_size_show_B = data_size_left;
                    }
                    else if(loaded_data_size < TB)
                    {
                        data_size_show_GB = data_size_left / GB;
                        data_size_left = data_size_left - data_size_show_GB * GB;

                        data_size_show_MB = data_size_left / MB;
                        data_size_left = data_size_left - data_size_show_MB * MB;

                        data_size_show_KB = data_size_left / KB;
                        data_size_left = data_size_left - data_size_show_KB * KB;

                        data_size_show_B = data_size_left;
                    }

                    Console.WriteLine("Progress:{0}|{1}: {2}G {3}M {4}K {5}B", read_cnt, ReturnByte.Length,
                    data_size_show_GB, data_size_show_MB, data_size_show_KB, data_size_show_B);

                    read_cnt++;               
                } 
            }

            br.Close();
			T.Close();

			System.DateTime end_time = new System.DateTime();
			end_time = System.DateTime.Now;

			MessageBox.Show("Start: " + start_time.ToString() + "\r\n" +
							"End: " + end_time.ToString() + "\r\n" +
							"Spend:" + (end_time - start_time).ToString(),
			"Finish!", MessageBoxButtons.OK);	

            BEThread.Abort("退出");     //结束线程
        }
    }

}
