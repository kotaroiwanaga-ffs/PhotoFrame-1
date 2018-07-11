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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.b004 = new System.Windows.Forms.Label();
            this.textBox_SaveAlbumName = new System.Windows.Forms.TextBox();
            this.button_SaveAlbumName = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_SaveAlbumName);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_SaveAlbumName);
            this.splitContainer1.Panel1.Controls.Add(this.b004);
            this.splitContainer1.Panel1.Controls.Add(this.radioButton2);
            this.splitContainer1.Panel1.Controls.Add(this.radioButton1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.button_Stop);
            this.splitContainer1.Panel2.Controls.Add(this.button_Next);
            this.splitContainer1.Panel2.Controls.Add(this.button_Back);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 460);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 0;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 85);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(177, 22);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "保存済みのアルバム";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 42);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(111, 22);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "リストビュー";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button_Next
            // 
            this.button_Next.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Next.Location = new System.Drawing.Point(522, 131);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(58, 102);
            this.button_Next.TabIndex = 2;
            this.button_Next.Text = "▶";
            this.button_Next.UseVisualStyleBackColor = true;
            // 
            // button_Back
            // 
            this.button_Back.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Back.Location = new System.Drawing.Point(56, 131);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(58, 102);
            this.button_Back.TabIndex = 1;
            this.button_Back.Text = "◀";
            this.button_Back.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(120, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 273);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(396, 273);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // b004
            // 
            this.b004.Location = new System.Drawing.Point(12, 226);
            this.b004.Name = "b004";
            this.b004.Size = new System.Drawing.Size(168, 54);
            this.b004.TabIndex = 2;
            this.b004.Text = "現在のスライドショーをアルバムとして保存";
            // 
            // textBox_SaveAlbumName
            // 
            this.textBox_SaveAlbumName.Location = new System.Drawing.Point(12, 283);
            this.textBox_SaveAlbumName.Multiline = true;
            this.textBox_SaveAlbumName.Name = "textBox_SaveAlbumName";
            this.textBox_SaveAlbumName.Size = new System.Drawing.Size(163, 52);
            this.textBox_SaveAlbumName.TabIndex = 3;
            // 
            // button_SaveAlbumName
            // 
            this.button_SaveAlbumName.Location = new System.Drawing.Point(83, 357);
            this.button_SaveAlbumName.Name = "button_SaveAlbumName";
            this.button_SaveAlbumName.Size = new System.Drawing.Size(92, 38);
            this.button_SaveAlbumName.TabIndex = 4;
            this.button_SaveAlbumName.Text = "保存";
            this.button_SaveAlbumName.UseVisualStyleBackColor = true;
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(158, 346);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(69, 69);
            this.button_Stop.TabIndex = 3;
            this.button_Stop.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(271, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 69);
            this.button1.TabIndex = 4;
            this.button1.Text = "||";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(376, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 69);
            this.button2.TabIndex = 5;
            this.button2.Text = "▶";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SldeShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SldeShow";
            this.Text = "SldeShow";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label b004;
        private System.Windows.Forms.Button button_SaveAlbumName;
        private System.Windows.Forms.TextBox textBox_SaveAlbumName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Stop;
    }
}