namespace PhotoFrameApp
{
    partial class SlideShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBox_AlbumName = new System.Windows.Forms.ComboBox();
            this.button_SaveAlbumName = new System.Windows.Forms.Button();
            this.textBox_SaveAlbumName = new System.Windows.Forms.TextBox();
            this.b004 = new System.Windows.Forms.Label();
            this.radioButton_AlbumSlideShow = new System.Windows.Forms.RadioButton();
            this.radioButton_ListViewSlideShow = new System.Windows.Forms.RadioButton();
            this.button_StartSlideShow = new System.Windows.Forms.Button();
            this.button_Pause = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_SlideShow = new System.Windows.Forms.PictureBox();
            this.timer_SlideShow = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SlideShow)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_AlbumName);
            this.splitContainer1.Panel1.Controls.Add(this.button_SaveAlbumName);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_SaveAlbumName);
            this.splitContainer1.Panel1.Controls.Add(this.b004);
            this.splitContainer1.Panel1.Controls.Add(this.radioButton_AlbumSlideShow);
            this.splitContainer1.Panel1.Controls.Add(this.radioButton_ListViewSlideShow);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button_StartSlideShow);
            this.splitContainer1.Panel2.Controls.Add(this.button_Pause);
            this.splitContainer1.Panel2.Controls.Add(this.button_Stop);
            this.splitContainer1.Panel2.Controls.Add(this.button_Next);
            this.splitContainer1.Panel2.Controls.Add(this.button_Back);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(600, 314);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // comboBox_AlbumName
            // 
            this.comboBox_AlbumName.Enabled = false;
            this.comboBox_AlbumName.FormattingEnabled = true;
            this.comboBox_AlbumName.Location = new System.Drawing.Point(12, 87);
            this.comboBox_AlbumName.Name = "comboBox_AlbumName";
            this.comboBox_AlbumName.Size = new System.Drawing.Size(121, 20);
            this.comboBox_AlbumName.TabIndex = 5;
            // 
            // button_SaveAlbumName
            // 
            this.button_SaveAlbumName.Location = new System.Drawing.Point(50, 238);
            this.button_SaveAlbumName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_SaveAlbumName.Name = "button_SaveAlbumName";
            this.button_SaveAlbumName.Size = new System.Drawing.Size(55, 25);
            this.button_SaveAlbumName.TabIndex = 4;
            this.button_SaveAlbumName.Text = "保存";
            this.button_SaveAlbumName.UseVisualStyleBackColor = true;
            this.button_SaveAlbumName.Click += new System.EventHandler(this.button_SaveAlbumName_Click);
            // 
            // textBox_SaveAlbumName
            // 
            this.textBox_SaveAlbumName.Location = new System.Drawing.Point(7, 189);
            this.textBox_SaveAlbumName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_SaveAlbumName.Multiline = true;
            this.textBox_SaveAlbumName.Name = "textBox_SaveAlbumName";
            this.textBox_SaveAlbumName.Size = new System.Drawing.Size(99, 36);
            this.textBox_SaveAlbumName.TabIndex = 3;
            // 
            // b004
            // 
            this.b004.Location = new System.Drawing.Point(7, 151);
            this.b004.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.b004.Name = "b004";
            this.b004.Size = new System.Drawing.Size(101, 36);
            this.b004.TabIndex = 2;
            this.b004.Text = "現在のスライドショーをアルバムとして保存";
            // 
            // radioButton_AlbumSlideShow
            // 
            this.radioButton_AlbumSlideShow.AutoSize = true;
            this.radioButton_AlbumSlideShow.Location = new System.Drawing.Point(8, 57);
            this.radioButton_AlbumSlideShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton_AlbumSlideShow.Name = "radioButton_AlbumSlideShow";
            this.radioButton_AlbumSlideShow.Size = new System.Drawing.Size(119, 16);
            this.radioButton_AlbumSlideShow.TabIndex = 1;
            this.radioButton_AlbumSlideShow.TabStop = true;
            this.radioButton_AlbumSlideShow.Text = "保存済みのアルバム";
            this.radioButton_AlbumSlideShow.UseVisualStyleBackColor = true;
            this.radioButton_AlbumSlideShow.CheckedChanged += new System.EventHandler(this.radioButton_AlbumSlideShow_CheckedChanged);
            // 
            // radioButton_ListViewSlideShow
            // 
            this.radioButton_ListViewSlideShow.AutoSize = true;
            this.radioButton_ListViewSlideShow.Checked = true;
            this.radioButton_ListViewSlideShow.Location = new System.Drawing.Point(8, 28);
            this.radioButton_ListViewSlideShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton_ListViewSlideShow.Name = "radioButton_ListViewSlideShow";
            this.radioButton_ListViewSlideShow.Size = new System.Drawing.Size(73, 16);
            this.radioButton_ListViewSlideShow.TabIndex = 0;
            this.radioButton_ListViewSlideShow.TabStop = true;
            this.radioButton_ListViewSlideShow.Text = "リストビュー";
            this.radioButton_ListViewSlideShow.UseVisualStyleBackColor = true;
            this.radioButton_ListViewSlideShow.CheckedChanged += new System.EventHandler(this.radioButton_ListViewSlideShow_CheckedChanged);
            // 
            // button_StartSlideShow
            // 
            this.button_StartSlideShow.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_StartSlideShow.Location = new System.Drawing.Point(226, 231);
            this.button_StartSlideShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_StartSlideShow.Name = "button_StartSlideShow";
            this.button_StartSlideShow.Size = new System.Drawing.Size(41, 46);
            this.button_StartSlideShow.TabIndex = 5;
            this.button_StartSlideShow.Text = "▶";
            this.button_StartSlideShow.UseVisualStyleBackColor = true;
            this.button_StartSlideShow.Click += new System.EventHandler(this.button_StartSlideShow_Click);
            // 
            // button_Pause
            // 
            this.button_Pause.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Pause.Location = new System.Drawing.Point(163, 231);
            this.button_Pause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Pause.Name = "button_Pause";
            this.button_Pause.Size = new System.Drawing.Size(41, 46);
            this.button_Pause.TabIndex = 4;
            this.button_Pause.Text = "||";
            this.button_Pause.UseVisualStyleBackColor = true;
            this.button_Pause.Click += new System.EventHandler(this.button_Pause_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(95, 231);
            this.button_Stop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(41, 46);
            this.button_Stop.TabIndex = 3;
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_Next
            // 
            this.button_Next.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Next.Location = new System.Drawing.Point(313, 87);
            this.button_Next.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(35, 68);
            this.button_Next.TabIndex = 2;
            this.button_Next.Text = "▶";
            this.button_Next.UseVisualStyleBackColor = true;
            // 
            // button_Back
            // 
            this.button_Back.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Back.Location = new System.Drawing.Point(34, 87);
            this.button_Back.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(35, 68);
            this.button_Back.TabIndex = 1;
            this.button_Back.Text = "◀";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox_SlideShow);
            this.panel1.Location = new System.Drawing.Point(72, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 182);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox_SlideShow
            // 
            this.pictureBox_SlideShow.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_SlideShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_SlideShow.ImageLocation = "";
            this.pictureBox_SlideShow.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_SlideShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox_SlideShow.Name = "pictureBox_SlideShow";
            this.pictureBox_SlideShow.Size = new System.Drawing.Size(238, 182);
            this.pictureBox_SlideShow.TabIndex = 0;
            this.pictureBox_SlideShow.TabStop = false;
            // 
            // timer_SlideShow
            // 
            this.timer_SlideShow.Interval = 3000;
            this.timer_SlideShow.Tick += new System.EventHandler(this.button_StartSlideShow_Click);
            // 
            // SlideShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 314);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SlideShow";
            this.Text = "SldeShow";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SlideShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_SlideShow;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.RadioButton radioButton_AlbumSlideShow;
        private System.Windows.Forms.RadioButton radioButton_ListViewSlideShow;
        private System.Windows.Forms.Label b004;
        private System.Windows.Forms.Button button_SaveAlbumName;
        private System.Windows.Forms.TextBox textBox_SaveAlbumName;
        private System.Windows.Forms.Button button_StartSlideShow;
        private System.Windows.Forms.Button button_Pause;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.ComboBox comboBox_AlbumName;
        private System.Windows.Forms.Timer timer_SlideShow;
    }
}