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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_AutoPlay = new System.Windows.Forms.CheckBox();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.pictureBox_SelectedPhotos = new System.Windows.Forms.PictureBox();
            this.timer_ChangePhoto = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelectedPhotos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox_SelectedPhotos);
            this.panel1.Location = new System.Drawing.Point(336, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 662);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox_AutoPlay);
            this.panel2.Controls.Add(this.button_Next);
            this.panel2.Controls.Add(this.button_Back);
            this.panel2.Location = new System.Drawing.Point(305, 558);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(473, 81);
            this.panel2.TabIndex = 7;
            // 
            // checkBox_AutoPlay
            // 
            this.checkBox_AutoPlay.AutoSize = true;
            this.checkBox_AutoPlay.Checked = true;
            this.checkBox_AutoPlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AutoPlay.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox_AutoPlay.Location = new System.Drawing.Point(37, 22);
            this.checkBox_AutoPlay.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.checkBox_AutoPlay.Name = "checkBox_AutoPlay";
            this.checkBox_AutoPlay.Size = new System.Drawing.Size(155, 33);
            this.checkBox_AutoPlay.TabIndex = 9;
            this.checkBox_AutoPlay.Text = "自動再生";
            this.checkBox_AutoPlay.UseVisualStyleBackColor = true;
            this.checkBox_AutoPlay.CheckedChanged += new System.EventHandler(this.checkBox_AutoPlay_CheckedChanged);
            // 
            // button_Next
            // 
            this.button_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Next.Location = new System.Drawing.Point(385, 4);
            this.button_Next.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(83, 68);
            this.button_Next.TabIndex = 8;
            this.button_Next.Text = "▶";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // button_Back
            // 
            this.button_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Back.Location = new System.Drawing.Point(267, 4);
            this.button_Back.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(83, 68);
            this.button_Back.TabIndex = 7;
            this.button_Back.Text = "◀";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // pictureBox_SelectedPhotos
            // 
            this.pictureBox_SelectedPhotos.Location = new System.Drawing.Point(45, 31);
            this.pictureBox_SelectedPhotos.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox_SelectedPhotos.Name = "pictureBox_SelectedPhotos";
            this.pictureBox_SelectedPhotos.Size = new System.Drawing.Size(872, 506);
            this.pictureBox_SelectedPhotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_SelectedPhotos.TabIndex = 1;
            this.pictureBox_SelectedPhotos.TabStop = false;
            // 
            // timer_ChangePhoto
            // 
            this.timer_ChangePhoto.Tick += new System.EventHandler(this.timer_ChangePhoto_Tick);
            // 
            // SlideShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 675);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "SlideShow";
            this.Text = "SlideShow";
            this.Load += new System.EventHandler(this.SlideShow_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelectedPhotos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox_AutoPlay;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.PictureBox pictureBox_SelectedPhotos;
        private System.Windows.Forms.Timer timer_ChangePhoto;
    }
}