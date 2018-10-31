using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;


namespace Zgke
{
    /// 磁盘扇区
    ///
    public class DriverLoader
    {
        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;

        private const uint FILE_SHARE_READ = 0x00000001;
        private const uint FILE_SHARE_WRITE = 0x00000002;

        private const uint OPEN_EXISTING = 3;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern SafeFileHandle CreateFileA(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);


        private FileStream _DirverStream;
        private long disk_max_lba = 0;

        ///
        /// 扇区数
        ///
        public long SectorLength { get { return disk_max_lba; } }


        ///
        /// 获取磁盘扇区信息
        ///
        /// G:
        public DriverLoader(string DirverName, long max_lba)
        {
            if(DirverName == null && DirverName.Trim().Length == 0)
            {
                return;
            }

            Console.WriteLine("Open disk: {0}", DirverName);

			SafeFileHandle _DirverHandle = CreateFileA(DirverName, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
			
			try
			{
				_DirverStream = new FileStream(_DirverHandle, FileAccess.ReadWrite);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, _DirverHandle.ToString(), MessageBoxButtons.OK);
				while(true);
			}

			disk_max_lba = max_lba;
			Console.WriteLine("set max lba:{0}", max_lba);
        }


        ///
        /// 扇区显示转换
        ///
        /// 扇区长度512
        /// EB 52 90 ......55 AA
        public string GetString(byte[] SectorBytes)
        {
            if(SectorBytes.Length == 0)
            {
                return "";
            }

            StringBuilder ReturnText = new StringBuilder();

            int RowCount = 0;
            for(int i = 0; i < SectorBytes.Length; i++)
            {
                ReturnText.Append(SectorBytes[i].ToString("X02") + " ");

                if (RowCount == 15)
                {
                    ReturnText.Append("\r\n");
                    RowCount = -1;
                }

                RowCount++;
            }

            return ReturnText.ToString();
        }

        ///
        /// 读一个扇区
        ///
        /// 扇区号
        /// 如果扇区数字大于分区信息的扇区数返回NULL
        public byte[] ReadSector(long read_lba, int sector_count)
        {
			if(read_lba > disk_max_lba)
			{
				MessageBox.Show("Error Sector input: " + read_lba.ToString() + " max: " + disk_max_lba.ToString(),
					"Warning!", MessageBoxButtons.OK);
				return null;
			}

			long read_offset_bytes = read_lba * 512;
            int read_length_bytes = sector_count * 512;

			byte[] SectorBytes = new byte[read_length_bytes];

			//Console.WriteLine("read lba:{0} sector count:{1}", read_lba, sector_count);

			_DirverStream.Position = read_offset_bytes;
			try
			{
				_DirverStream.Read(SectorBytes, 0, read_length_bytes);		//获取扇区
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Read at " + read_lba.ToString(), MessageBoxButtons.OK);
				return null;
			}			
			
			//for(int i = 0; i < SectorBytes.Length; i++)
			//{
			//	Console.Write("{0} ", SectorBytes[i]);
			//}			
			//Console.Write("\r\n");

			return SectorBytes;
        }
        ///
        /// 写入数据
        ///
        /// 扇区长度512
        /// 扇区位置
        public void WritSector(byte[] SectorBytes, long write_lba, int sector_count)
        {
			if(write_lba > disk_max_lba)
			{
				MessageBox.Show("Error Sector input: " + write_lba.ToString() + "max: " + disk_max_lba.ToString(),
					"Warning!", MessageBoxButtons.OK);
				return;
			}

			long write_offset_bytes = write_lba * 512;
			int write_length_bytes = sector_count * 512;

			if(write_length_bytes == 0)
			{
				MessageBox.Show("Error Data length", "Warning!", MessageBoxButtons.OK);
				return;
			}

			//Console.WriteLine("write lba:{0} sector count:{1} buffer:{2}", write_lba, sector_count, SectorBytes.Length);
			//for(int i = 0; i < SectorBytes.Length; i++)
			//{
			//	Console.Write("{0} ", SectorBytes[i]);
			//}
			//Console.Write("\r\n");

			_DirverStream.Position = write_offset_bytes;
			_DirverStream.Write(SectorBytes, 0, write_length_bytes);		//写入扇区
        }
        ///
        /// 关闭
        ///
        public void Close()
        {
            _DirverStream.Close();
        }
    }
}
