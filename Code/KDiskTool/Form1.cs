using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Management;
using System.IO;
using System.Threading;     //使用线程

namespace KDiskTool
{
    public partial class Form_KDisk : Form
    {
        //常量
        private const int _VersionGit = 2;

        public Form_KDisk()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "KDisk Git" + _VersionGit.ToString();

			using  (ManagementObjectSearcher mydisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
			{
				foreach (ManagementObject mydisk in mydisks.Get())
				{
					comboBox_Disk.Items.Add(mydisk.Properties["Name"].Value.ToString());

                    Console.WriteLine("n:{0} s:{1}", mydisk.ToString(), mydisk.Properties["Name"].Value.ToString());
				}

				mydisks.Dispose();
			}

			DriveInfo[] allDrives = DriveInfo.GetDrives();
			foreach(DriveInfo d in allDrives)
			{
				comboBox_Disk.Items.Add(d.Name);
			}
        }

		bool disk_has_file_system = false;

		private void comboBox_Disk_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBox_Data.Text = "";
			disk_has_file_system = false;

			using(ManagementObjectSearcher mydisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
			{
				foreach(ManagementObject mydisk in mydisks.Get())
				{
                    Console.WriteLine("n:{0} s:{1}", mydisk.Properties["Model"].Value.ToString(),
                        mydisk.Properties["TotalSectors"].Value.ToString());

                    if(comboBox_Disk.SelectedItem.ToString() == mydisk.Properties["Name"].Value.ToString())
                    {
                        long size = Convert.ToInt64(mydisk.Properties["Size"].Value.ToString());
                        textBox_Byte.Text = size.ToString();
                        textBox_Sector.Text = (size / 512).ToString();
                        textBox_GB.Text = (size / 1024 / 1024 / 1024).ToString();

						textBox_Data.Text += "Caption: " + mydisk.Properties["Caption"].Value.ToString() + "\r\n";
						textBox_Data.Text += "InterfaceType: " + mydisk.Properties["InterfaceType"].Value.ToString() + "\r\n";
						textBox_Data.Text += "Model: " + mydisk.Properties["Model"].Value.ToString() + "\r\n";
						textBox_Data.Text += "DeviceID: " + mydisk.Properties["DeviceID"].Value.ToString() + "\r\n";
						textBox_Data.Text += "Description: " + mydisk.Properties["Description"].Value.ToString() + "\r\n";
						textBox_Data.Text += "PNPDeviceID: " + mydisk.Properties["PNPDeviceID"].Value.ToString() + "\r\n";
						textBox_Data.Text += "Partitions: " + mydisk.Properties["Partitions"].Value.ToString() + "\r\n";

						if(Convert.ToInt64(mydisk.Properties["Partitions"].Value.ToString()) > 0)
						{
							disk_has_file_system = true;
						}
                    }
				}

				mydisks.Dispose();
			}

			DriveInfo[] allDrives = DriveInfo.GetDrives();
			foreach(DriveInfo d in allDrives)
			{
				if(comboBox_Disk.SelectedItem.ToString() == d.Name)
				{
					if(d.DriveType.ToString() == "Fixed")
					{
						textBox_Byte.Text = d.TotalSize.ToString();
						textBox_Sector.Text = (d.TotalSize / 512).ToString();
						textBox_GB.Text = (d.TotalSize / 1024 / 1024 / 1024).ToString();						

						if(d.IsReady)
						{
							textBox_Data.Text += "卷标:" + d.VolumeLabel.ToString() + "\r\n";
							textBox_Data.Text += "文件系统:" + d.DriveFormat.ToString() + "\r\n";
							textBox_Data.Text += "当前可用空间:" + d.AvailableFreeSpace.ToString() + "\r\n";
							textBox_Data.Text += "可用空间:" + d.TotalFreeSpace.ToString() + "\r\n";
						}				
					}
					else
					{
						textBox_Byte.Text = "0";
						textBox_GB.Text = "0";
					}
				}
			}
		}        

        private void button_LoadImg_Click(object sender, EventArgs e)
        {
            //打开文件
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = "bin";
            dlg.Filter = "bin Files|*.bin;*.img";

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
            }

            if(fileName == null)
            {
                return;
            }

            textBox_ImgPath.Text = fileName;

            System.IO.FileInfo fileInfo = null;
            try
            {
                fileInfo = new System.IO.FileInfo(fileName);
            }
            catch(Exception x)
            {
                Console.WriteLine(x.Message);
                return;
            }
            // 如果文件存在
            if(fileInfo != null && fileInfo.Exists)
            {
                System.Diagnostics.FileVersionInfo info = System.Diagnostics.FileVersionInfo.GetVersionInfo(fileName);
                Console.WriteLine("文件名称=" + info.FileName);
                Console.WriteLine("产品名称=" + info.ProductName);
                Console.WriteLine("公司名称=" + info.CompanyName);
                Console.WriteLine("文件版本=" + info.FileVersion);
                Console.WriteLine("产品版本=" + info.ProductVersion);
                // 通常版本号显示为「主版本号.次版本号.生成号.专用部件号」
                Console.WriteLine("系统显示文件版本：" + info.ProductMajorPart + '.' + info.ProductMinorPart + '.' + info.ProductBuildPart + '.' + info.ProductPrivatePart);
                Console.WriteLine("文件说明=" + info.FileDescription);
                Console.WriteLine("文件语言=" + info.Language);
                Console.WriteLine("原始文件名称=" + info.OriginalFilename);
                Console.WriteLine("文件版权=" + info.LegalCopyright);
                Console.WriteLine("文件大小=" + System.Math.Ceiling(fileInfo.Length / 1024.0) + " KB");
            }
            else
            {
                Console.WriteLine("指定的文件路径不正确!");
                return;
            }

            img_total_length = fileInfo.Length;

			textBox_Progress.Text = "0 " + " : " + img_total_length.ToString() + "(0%)";			
        }

        private void button_Copy_Click(object sender, EventArgs e)
        {
            if(comboBox_Disk.SelectedIndex == -1)
            {
                MessageBox.Show("Please sectet the target disk!", "Error!");
                return;
            }

            if(disk_has_file_system == true)
            {
                //DialogResult result = DialogResult.Cancel;
                //result = MessageBox.Show("Write to the disk with FILE SYSTEM??", "Warning!",
                //     MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                MessageBox.Show("Write to the disk with FILE SYSTEM!", "Error!");
                return;
            }

            if(fileName == null)
            {
                MessageBox.Show("Please sectet the source image!", "Error!");
                return;
            }

			int max_lba = Convert.ToInt32(textBox_Sector.Text) - 1;
			T = new Zgke.DriverLoader(comboBox_Disk.SelectedItem.ToString(), max_lba);

            // 读取文件
            try
            {
                br = new BinaryReader(new FileStream(fileName, FileMode.Open));
            }
            catch(IOException x)
            {
                MessageBox.Show(x.Message, "Error!");
                return;
            }

            /**********************创建线程****************************/
            string strInfo = string.Empty;
            BEThread = new Thread(new ThreadStart(BEThreadEntry));   //实例化Thread线程对象

            strInfo = "The managed Thread ID:" + BEThread.ManagedThreadId + "\n";
            strInfo += "Thread Name:" + BEThread.Name + "\n";
            strInfo += "Thread State:" + BEThread.ThreadState.ToString() + "\n";
            strInfo += "Thread Priority:" + BEThread.Priority.ToString() + "\n";
            strInfo += "Is Backgroud" + BEThread.IsBackground + "\n";
            Console.WriteLine(strInfo);

            //BEThread.Abort("退出");     //结束线程
            BEThread.IsBackground = true;//设置为后台程序，它的主线程结束，它也一起结束                                       
            BEThread.Start();                                               //启动线程
            /**********************创建线程****************************/
        }
		public string ShowString(byte[] SectorBytes)
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

				if(RowCount == 15)
				{
					ReturnText.Append("\r\n");
					RowCount = -1;
				}

				RowCount++;
			}

			return ReturnText.ToString();
		}

		byte[] data_buffer;
		Zgke.DriverLoader T = null;

		private void button_Read_Click(object sender, EventArgs e)
		{
			if(comboBox_Disk.SelectedIndex == -1)
			{
				MessageBox.Show("Please sectet the disk at fisrt!", "Warning!");
				return;
			}

			int max_lba = Convert.ToInt32(textBox_Sector.Text) - 1;
			
			T = new Zgke.DriverLoader(comboBox_Disk.SelectedItem.ToString(), max_lba);

			int lba = Convert.ToInt32(textBox_lba.Text);
			int length = Convert.ToInt32(textBox_Length.Text);

			data_buffer = T.ReadSector(lba, length);			
			T.Close();

			textBox_Data.Text = T.GetString(data_buffer);
		}

		private void button_Write_Click(object sender, EventArgs e)
		{
			if(comboBox_Disk.SelectedIndex == -1)
			{
				MessageBox.Show("Please sectet the disk at fisrt!", "Warning!");
				return;
			}

            if( (data_buffer == null) || 
                (data_buffer.Length != Convert.ToInt32(textBox_PaddingLength.Text.Trim()))
               )
			{
				MessageBox.Show("Please fullfill the data buffer before write", "Warning!");
				return;
			}

			int max_lba = Convert.ToInt32(textBox_Sector.Text) - 1;

			T = new Zgke.DriverLoader(comboBox_Disk.SelectedItem.ToString(), max_lba);

			int lba = Convert.ToInt32(textBox_lba.Text);
			int length = Convert.ToInt32(textBox_Length.Text);

			T.WritSector(data_buffer, lba, length);
			T.Close();
		}

		private void button_fullfill_Click(object sender, EventArgs e)
		{
            int length;
            byte pattern;

            // 读取文件
            length = Convert.ToInt32(textBox_PaddingLength.Text.Trim());
            pattern = Convert.ToByte(textBox_PaddingPattern.Text.Trim());

			byte[] SectorBytes = new byte[length];

			for(int i = 0; i < length; i++)
			{
				SectorBytes[i] = pattern;
			}
			data_buffer = SectorBytes;
			textBox_Data.Text = ShowString(data_buffer);
			Console.WriteLine("legnth of data buffer pattern:{0}, length:{1}", pattern, data_buffer.Length);
		}

		private void button_Random_Click(object sender, EventArgs e)
		{
			int length = Convert.ToInt32(textBox_PaddingLength.Text);

			Random rd = new Random();

			byte[] SectorBytes = new byte[length];

			for(int i = 0; i < length; i++)
			{
				SectorBytes[i] = (byte)rd.Next(0, 255);
			}
			data_buffer = SectorBytes;
			textBox_Data.Text = ShowString(data_buffer);
			Console.WriteLine("legnth of data buffer pattern:{0}, length:{1}", (byte)rd.Next(0, 255), data_buffer.Length);
		}

		private void button_CheckRealSize_Click(object sender, EventArgs e)
		{
			if(comboBox_Disk.SelectedIndex == -1)
			{
				MessageBox.Show("Please sectet the disk at fisrt!", "Warning!");
				return;
			}

			long tmp_max_lba = Convert.ToInt64(textBox_Sector.Text);

			T = new Zgke.DriverLoader(comboBox_Disk.SelectedItem.ToString(), tmp_max_lba*2);			

			tmp_max_lba = tmp_max_lba / 8 * 8;
			while(true)
			{
				Console.WriteLine("Check lba:{0}", tmp_max_lba);                

				data_buffer = T.ReadSector(tmp_max_lba, 8);			
				if(data_buffer == null)
				{
					break;
				}
				tmp_max_lba += 8;
			}

            textBox_Progress.Text = "Check lba:" + tmp_max_lba.ToString();

			textBox_Byte.Text = (tmp_max_lba*512).ToString();
			textBox_Sector.Text = tmp_max_lba.ToString();
			textBox_GB.Text = ((tmp_max_lba * 512) / 1024 / 1024 / 1024).ToString();

			T.Close();
		}

        private void Form_KDisk_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(BEThread != null)
            {
                BEThread.Abort("退出");     //结束线程
            }
        }
    }
}
