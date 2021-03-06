﻿namespace KDiskTool
{
    partial class Form_KDisk
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_KDisk));
            this.textBox_Data = new System.Windows.Forms.TextBox();
            this.comboBox_Disk = new System.Windows.Forms.ComboBox();
            this.label_Disk = new System.Windows.Forms.Label();
            this.label_Byte = new System.Windows.Forms.Label();
            this.label_GB = new System.Windows.Forms.Label();
            this.textBox_Byte = new System.Windows.Forms.TextBox();
            this.textBox_GB = new System.Windows.Forms.TextBox();
            this.label_progress = new System.Windows.Forms.Label();
            this.textBox_Sector = new System.Windows.Forms.TextBox();
            this.label_Sector = new System.Windows.Forms.Label();
            this.button_LoadImg = new System.Windows.Forms.Button();
            this.textBox_ImgPath = new System.Windows.Forms.TextBox();
            this.label_Img = new System.Windows.Forms.Label();
            this.button_Copy = new System.Windows.Forms.Button();
            this.button_fullfill = new System.Windows.Forms.Button();
            this.label_PaddingLength = new System.Windows.Forms.Label();
            this.textBox_PaddingLength = new System.Windows.Forms.TextBox();
            this.label_PaddingPattern = new System.Windows.Forms.Label();
            this.textBox_PaddingPattern = new System.Windows.Forms.TextBox();
            this.button_Random = new System.Windows.Forms.Button();
            this.button_Write = new System.Windows.Forms.Button();
            this.label_SectorCount = new System.Windows.Forms.Label();
            this.label_SetLBA = new System.Windows.Forms.Label();
            this.textBox_Length = new System.Windows.Forms.TextBox();
            this.textBox_lba = new System.Windows.Forms.TextBox();
            this.button_Read = new System.Windows.Forms.Button();
            this.textBox_Progress = new System.Windows.Forms.TextBox();
            this.textBox_Ignore = new System.Windows.Forms.TextBox();
            this.label_Ignore = new System.Windows.Forms.Label();
            this.button_CheckRealSize = new System.Windows.Forms.Button();
            this.checkBox_Ignore = new System.Windows.Forms.CheckBox();
            this.label_CurrentSpeed = new System.Windows.Forms.Label();
            this.label_AverageSpeed = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_WrDiskBlk = new System.Windows.Forms.Label();
            this.label_RdImgBlk = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Data
            // 
            this.textBox_Data.Location = new System.Drawing.Point(6, 12);
            this.textBox_Data.Multiline = true;
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Data.Size = new System.Drawing.Size(362, 403);
            this.textBox_Data.TabIndex = 1;
            // 
            // comboBox_Disk
            // 
            this.comboBox_Disk.FormattingEnabled = true;
            this.comboBox_Disk.Location = new System.Drawing.Point(161, 561);
            this.comboBox_Disk.Name = "comboBox_Disk";
            this.comboBox_Disk.Size = new System.Drawing.Size(148, 20);
            this.comboBox_Disk.TabIndex = 6;
            this.comboBox_Disk.SelectedIndexChanged += new System.EventHandler(this.comboBox_Disk_SelectedIndexChanged);
            // 
            // label_Disk
            // 
            this.label_Disk.AutoSize = true;
            this.label_Disk.Location = new System.Drawing.Point(120, 564);
            this.label_Disk.Name = "label_Disk";
            this.label_Disk.Size = new System.Drawing.Size(35, 12);
            this.label_Disk.TabIndex = 7;
            this.label_Disk.Text = "Disk:";
            // 
            // label_Byte
            // 
            this.label_Byte.AutoSize = true;
            this.label_Byte.Location = new System.Drawing.Point(85, 538);
            this.label_Byte.Name = "label_Byte";
            this.label_Byte.Size = new System.Drawing.Size(29, 12);
            this.label_Byte.TabIndex = 8;
            this.label_Byte.Text = "Byte";
            // 
            // label_GB
            // 
            this.label_GB.AutoSize = true;
            this.label_GB.Location = new System.Drawing.Point(85, 484);
            this.label_GB.Name = "label_GB";
            this.label_GB.Size = new System.Drawing.Size(17, 12);
            this.label_GB.TabIndex = 9;
            this.label_GB.Text = "GB";
            // 
            // textBox_Byte
            // 
            this.textBox_Byte.Location = new System.Drawing.Point(6, 535);
            this.textBox_Byte.Name = "textBox_Byte";
            this.textBox_Byte.ReadOnly = true;
            this.textBox_Byte.Size = new System.Drawing.Size(79, 21);
            this.textBox_Byte.TabIndex = 13;
            this.textBox_Byte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_GB
            // 
            this.textBox_GB.Location = new System.Drawing.Point(6, 478);
            this.textBox_GB.Name = "textBox_GB";
            this.textBox_GB.ReadOnly = true;
            this.textBox_GB.Size = new System.Drawing.Size(79, 21);
            this.textBox_GB.TabIndex = 14;
            this.textBox_GB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Location = new System.Drawing.Point(120, 484);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(59, 12);
            this.label_progress.TabIndex = 17;
            this.label_progress.Text = "progress:";
            // 
            // textBox_Sector
            // 
            this.textBox_Sector.Location = new System.Drawing.Point(6, 508);
            this.textBox_Sector.Name = "textBox_Sector";
            this.textBox_Sector.ReadOnly = true;
            this.textBox_Sector.Size = new System.Drawing.Size(79, 21);
            this.textBox_Sector.TabIndex = 19;
            this.textBox_Sector.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Sector
            // 
            this.label_Sector.AutoSize = true;
            this.label_Sector.Location = new System.Drawing.Point(85, 511);
            this.label_Sector.Name = "label_Sector";
            this.label_Sector.Size = new System.Drawing.Size(23, 12);
            this.label_Sector.TabIndex = 18;
            this.label_Sector.Text = "Sec";
            // 
            // button_LoadImg
            // 
            this.button_LoadImg.Location = new System.Drawing.Point(313, 530);
            this.button_LoadImg.Name = "button_LoadImg";
            this.button_LoadImg.Size = new System.Drawing.Size(55, 23);
            this.button_LoadImg.TabIndex = 20;
            this.button_LoadImg.Text = "Image";
            this.button_LoadImg.UseVisualStyleBackColor = true;
            this.button_LoadImg.Click += new System.EventHandler(this.button_LoadImg_Click);
            // 
            // textBox_ImgPath
            // 
            this.textBox_ImgPath.Location = new System.Drawing.Point(161, 532);
            this.textBox_ImgPath.Name = "textBox_ImgPath";
            this.textBox_ImgPath.Size = new System.Drawing.Size(148, 21);
            this.textBox_ImgPath.TabIndex = 21;
            this.textBox_ImgPath.Text = "d:\\???.img";
            // 
            // label_Img
            // 
            this.label_Img.AutoSize = true;
            this.label_Img.Location = new System.Drawing.Point(120, 535);
            this.label_Img.Name = "label_Img";
            this.label_Img.Size = new System.Drawing.Size(41, 12);
            this.label_Img.TabIndex = 22;
            this.label_Img.Text = "Image:";
            // 
            // button_Copy
            // 
            this.button_Copy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Copy.ForeColor = System.Drawing.Color.Red;
            this.button_Copy.Location = new System.Drawing.Point(6, 417);
            this.button_Copy.Name = "button_Copy";
            this.button_Copy.Size = new System.Drawing.Size(44, 23);
            this.button_Copy.TabIndex = 25;
            this.button_Copy.Text = "Copy";
            this.button_Copy.UseVisualStyleBackColor = true;
            this.button_Copy.Click += new System.EventHandler(this.button_Copy_Click);
            // 
            // button_fullfill
            // 
            this.button_fullfill.Location = new System.Drawing.Point(313, 418);
            this.button_fullfill.Name = "button_fullfill";
            this.button_fullfill.Size = new System.Drawing.Size(55, 23);
            this.button_fullfill.TabIndex = 27;
            this.button_fullfill.Text = "FullFill";
            this.button_fullfill.UseVisualStyleBackColor = true;
            this.button_fullfill.Click += new System.EventHandler(this.button_fullfill_Click);
            // 
            // label_PaddingLength
            // 
            this.label_PaddingLength.AutoSize = true;
            this.label_PaddingLength.Location = new System.Drawing.Point(161, 423);
            this.label_PaddingLength.Name = "label_PaddingLength";
            this.label_PaddingLength.Size = new System.Drawing.Size(47, 12);
            this.label_PaddingLength.TabIndex = 29;
            this.label_PaddingLength.Text = "Length:";
            // 
            // textBox_PaddingLength
            // 
            this.textBox_PaddingLength.Location = new System.Drawing.Point(214, 419);
            this.textBox_PaddingLength.Name = "textBox_PaddingLength";
            this.textBox_PaddingLength.Size = new System.Drawing.Size(36, 21);
            this.textBox_PaddingLength.TabIndex = 28;
            this.textBox_PaddingLength.Text = "4096";
            this.textBox_PaddingLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_PaddingPattern
            // 
            this.label_PaddingPattern.AutoSize = true;
            this.label_PaddingPattern.Location = new System.Drawing.Point(61, 422);
            this.label_PaddingPattern.Name = "label_PaddingPattern";
            this.label_PaddingPattern.Size = new System.Drawing.Size(65, 12);
            this.label_PaddingPattern.TabIndex = 31;
            this.label_PaddingPattern.Text = "Pattern:0x";
            // 
            // textBox_PaddingPattern
            // 
            this.textBox_PaddingPattern.Location = new System.Drawing.Point(126, 419);
            this.textBox_PaddingPattern.Name = "textBox_PaddingPattern";
            this.textBox_PaddingPattern.Size = new System.Drawing.Size(27, 21);
            this.textBox_PaddingPattern.TabIndex = 30;
            this.textBox_PaddingPattern.Text = "0";
            this.textBox_PaddingPattern.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_PaddingPattern.TextChanged += new System.EventHandler(this.textBox_PaddingPattern_TextChanged);
            // 
            // button_Random
            // 
            this.button_Random.Location = new System.Drawing.Point(252, 418);
            this.button_Random.Name = "button_Random";
            this.button_Random.Size = new System.Drawing.Size(55, 23);
            this.button_Random.TabIndex = 32;
            this.button_Random.Text = "Random";
            this.button_Random.UseVisualStyleBackColor = true;
            this.button_Random.Click += new System.EventHandler(this.button_Random_Click);
            // 
            // button_Write
            // 
            this.button_Write.Location = new System.Drawing.Point(252, 448);
            this.button_Write.Name = "button_Write";
            this.button_Write.Size = new System.Drawing.Size(55, 23);
            this.button_Write.TabIndex = 44;
            this.button_Write.Text = "Write";
            this.button_Write.UseVisualStyleBackColor = true;
            this.button_Write.Click += new System.EventHandler(this.button_Write_Click);
            // 
            // label_SectorCount
            // 
            this.label_SectorCount.AutoSize = true;
            this.label_SectorCount.Location = new System.Drawing.Point(155, 453);
            this.label_SectorCount.Name = "label_SectorCount";
            this.label_SectorCount.Size = new System.Drawing.Size(59, 12);
            this.label_SectorCount.TabIndex = 43;
            this.label_SectorCount.Text = "Len(dec):";
            this.label_SectorCount.Click += new System.EventHandler(this.label_SectorCount_Click);
            // 
            // label_SetLBA
            // 
            this.label_SetLBA.AutoSize = true;
            this.label_SetLBA.Location = new System.Drawing.Point(4, 453);
            this.label_SetLBA.Name = "label_SetLBA";
            this.label_SetLBA.Size = new System.Drawing.Size(59, 12);
            this.label_SetLBA.TabIndex = 42;
            this.label_SetLBA.Text = "LBA(hex):";
            this.label_SetLBA.Click += new System.EventHandler(this.label_SetLBA_Click);
            // 
            // textBox_Length
            // 
            this.textBox_Length.Location = new System.Drawing.Point(214, 449);
            this.textBox_Length.Name = "textBox_Length";
            this.textBox_Length.Size = new System.Drawing.Size(36, 21);
            this.textBox_Length.TabIndex = 41;
            this.textBox_Length.Text = "1";
            this.textBox_Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_lba
            // 
            this.textBox_lba.Location = new System.Drawing.Point(63, 450);
            this.textBox_lba.Name = "textBox_lba";
            this.textBox_lba.Size = new System.Drawing.Size(90, 21);
            this.textBox_lba.TabIndex = 40;
            this.textBox_lba.Text = "0";
            this.textBox_lba.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button_Read
            // 
            this.button_Read.Location = new System.Drawing.Point(313, 448);
            this.button_Read.Name = "button_Read";
            this.button_Read.Size = new System.Drawing.Size(55, 23);
            this.button_Read.TabIndex = 39;
            this.button_Read.Text = "Read";
            this.button_Read.UseVisualStyleBackColor = true;
            this.button_Read.Click += new System.EventHandler(this.button_Read_Click);
            // 
            // textBox_Progress
            // 
            this.textBox_Progress.Location = new System.Drawing.Point(178, 481);
            this.textBox_Progress.Name = "textBox_Progress";
            this.textBox_Progress.ReadOnly = true;
            this.textBox_Progress.Size = new System.Drawing.Size(190, 21);
            this.textBox_Progress.TabIndex = 45;
            this.textBox_Progress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_Ignore
            // 
            this.textBox_Ignore.Location = new System.Drawing.Point(178, 505);
            this.textBox_Ignore.Name = "textBox_Ignore";
            this.textBox_Ignore.ReadOnly = true;
            this.textBox_Ignore.Size = new System.Drawing.Size(190, 21);
            this.textBox_Ignore.TabIndex = 47;
            this.textBox_Ignore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Ignore
            // 
            this.label_Ignore.AutoSize = true;
            this.label_Ignore.Location = new System.Drawing.Point(120, 508);
            this.label_Ignore.Name = "label_Ignore";
            this.label_Ignore.Size = new System.Drawing.Size(47, 12);
            this.label_Ignore.TabIndex = 46;
            this.label_Ignore.Text = "Ignore:";
            // 
            // button_CheckRealSize
            // 
            this.button_CheckRealSize.Location = new System.Drawing.Point(313, 559);
            this.button_CheckRealSize.Name = "button_CheckRealSize";
            this.button_CheckRealSize.Size = new System.Drawing.Size(55, 23);
            this.button_CheckRealSize.TabIndex = 48;
            this.button_CheckRealSize.Text = "Check";
            this.button_CheckRealSize.UseVisualStyleBackColor = true;
            this.button_CheckRealSize.Click += new System.EventHandler(this.button_CheckRealSize_Click);
            // 
            // checkBox_Ignore
            // 
            this.checkBox_Ignore.AutoSize = true;
            this.checkBox_Ignore.Location = new System.Drawing.Point(6, 564);
            this.checkBox_Ignore.Name = "checkBox_Ignore";
            this.checkBox_Ignore.Size = new System.Drawing.Size(90, 16);
            this.checkBox_Ignore.TabIndex = 49;
            this.checkBox_Ignore.Text = "Ignore Zero";
            this.checkBox_Ignore.UseVisualStyleBackColor = true;
            // 
            // label_CurrentSpeed
            // 
            this.label_CurrentSpeed.AutoSize = true;
            this.label_CurrentSpeed.Location = new System.Drawing.Point(161, 584);
            this.label_CurrentSpeed.Name = "label_CurrentSpeed";
            this.label_CurrentSpeed.Size = new System.Drawing.Size(53, 12);
            this.label_CurrentSpeed.TabIndex = 50;
            this.label_CurrentSpeed.Text = "Current:";
            // 
            // label_AverageSpeed
            // 
            this.label_AverageSpeed.AutoSize = true;
            this.label_AverageSpeed.Location = new System.Drawing.Point(161, 599);
            this.label_AverageSpeed.Name = "label_AverageSpeed";
            this.label_AverageSpeed.Size = new System.Drawing.Size(53, 12);
            this.label_AverageSpeed.TabIndex = 51;
            this.label_AverageSpeed.Text = "Average:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_WrDiskBlk
            // 
            this.label_WrDiskBlk.AutoSize = true;
            this.label_WrDiskBlk.Location = new System.Drawing.Point(4, 584);
            this.label_WrDiskBlk.Name = "label_WrDiskBlk";
            this.label_WrDiskBlk.Size = new System.Drawing.Size(77, 12);
            this.label_WrDiskBlk.TabIndex = 52;
            this.label_WrDiskBlk.Text = "Wr disk Blk:";
            // 
            // label_RdImgBlk
            // 
            this.label_RdImgBlk.AutoSize = true;
            this.label_RdImgBlk.Location = new System.Drawing.Point(4, 599);
            this.label_RdImgBlk.Name = "label_RdImgBlk";
            this.label_RdImgBlk.Size = new System.Drawing.Size(71, 12);
            this.label_RdImgBlk.TabIndex = 53;
            this.label_RdImgBlk.Text = "Rd img Blk:";
            // 
            // Form_KDisk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 622);
            this.Controls.Add(this.label_RdImgBlk);
            this.Controls.Add(this.label_WrDiskBlk);
            this.Controls.Add(this.label_AverageSpeed);
            this.Controls.Add(this.label_CurrentSpeed);
            this.Controls.Add(this.checkBox_Ignore);
            this.Controls.Add(this.button_CheckRealSize);
            this.Controls.Add(this.textBox_Ignore);
            this.Controls.Add(this.label_Ignore);
            this.Controls.Add(this.textBox_Progress);
            this.Controls.Add(this.button_Write);
            this.Controls.Add(this.label_SectorCount);
            this.Controls.Add(this.label_SetLBA);
            this.Controls.Add(this.textBox_Length);
            this.Controls.Add(this.textBox_lba);
            this.Controls.Add(this.button_Read);
            this.Controls.Add(this.button_Random);
            this.Controls.Add(this.label_PaddingPattern);
            this.Controls.Add(this.textBox_PaddingPattern);
            this.Controls.Add(this.label_PaddingLength);
            this.Controls.Add(this.textBox_PaddingLength);
            this.Controls.Add(this.button_fullfill);
            this.Controls.Add(this.button_Copy);
            this.Controls.Add(this.label_Img);
            this.Controls.Add(this.textBox_ImgPath);
            this.Controls.Add(this.button_LoadImg);
            this.Controls.Add(this.textBox_Sector);
            this.Controls.Add(this.label_Sector);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.textBox_GB);
            this.Controls.Add(this.textBox_Byte);
            this.Controls.Add(this.label_GB);
            this.Controls.Add(this.label_Byte);
            this.Controls.Add(this.label_Disk);
            this.Controls.Add(this.comboBox_Disk);
            this.Controls.Add(this.textBox_Data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_KDisk";
            this.Text = "KDisk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_KDisk_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.ComboBox comboBox_Disk;
        private System.Windows.Forms.Label label_Disk;
		private System.Windows.Forms.Label label_Byte;
		private System.Windows.Forms.Label label_GB;
		private System.Windows.Forms.TextBox textBox_Byte;
		private System.Windows.Forms.TextBox textBox_GB;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.TextBox textBox_Sector;
        private System.Windows.Forms.Label label_Sector;
        private System.Windows.Forms.Button button_LoadImg;
        private System.Windows.Forms.TextBox textBox_ImgPath;
		private System.Windows.Forms.Label label_Img;
		private System.Windows.Forms.Button button_Copy;
		private System.Windows.Forms.Button button_fullfill;
		private System.Windows.Forms.Label label_PaddingLength;
		private System.Windows.Forms.TextBox textBox_PaddingLength;
		private System.Windows.Forms.Label label_PaddingPattern;
		private System.Windows.Forms.TextBox textBox_PaddingPattern;
		private System.Windows.Forms.Button button_Random;
		private System.Windows.Forms.Button button_Write;
		private System.Windows.Forms.Label label_SectorCount;
		private System.Windows.Forms.Label label_SetLBA;
		private System.Windows.Forms.TextBox textBox_Length;
		private System.Windows.Forms.TextBox textBox_lba;
		private System.Windows.Forms.Button button_Read;
		private System.Windows.Forms.TextBox textBox_Progress;
        private System.Windows.Forms.TextBox textBox_Ignore;
		private System.Windows.Forms.Label label_Ignore;
		private System.Windows.Forms.Button button_CheckRealSize;
		private System.Windows.Forms.CheckBox checkBox_Ignore;
        private System.Windows.Forms.Label label_CurrentSpeed;
        private System.Windows.Forms.Label label_AverageSpeed;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_WrDiskBlk;
        private System.Windows.Forms.Label label_RdImgBlk;
    }
}

