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
            this.comboBox_AlbumName = new System.Windows.Forms.ComboBox();
            this.button_SaveAlbumName = new System.Windows.Forms.Button();
            this.textBox_SaveAlbumName = new System.Windows.Forms.TextBox();
            this.b004 = new System.Windows.Forms.Label();
            this.radioButton_AlbumSlideShow = new System.Windows.Forms.RadioButton();
            this.radioButton_ListViewSlideShow = new System.Windows.Forms.RadioButton();
            this.button_StartSlideShow = new System.Windows.Forms.Button();
            this.button_Pause_SlideShow = new System.Windows.Forms.Button();
            this.button_StopSlideShow = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.pictureBox_SlideShow = new System.Windows.Forms.PictureBox();
            this.timer_SlideShow = new System.Windows.Forms.Timer(this.components);
            this.button_Next = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SlideShow)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_AlbumName
            // 
            this.comboBox_AlbumName.Enabled = false;
            this.comboBox_AlbumName.FormattingEnabled = true;
            this.comboBox_AlbumName.Location = new System.Drawing.Point(43, 39);
            this.comboBox_AlbumName.Name = "comboBox_AlbumName";
            this.comboBox_AlbumName.Size = new System.Drawing.Size(80, 20);
            this.comboBox_AlbumName.TabIndex = 5;
            this.comboBox_AlbumName.SelectedIndexChanged += new System.EventHandler(this.comboBox_AlbumName_SelectedIndexChanged);
            // 
            // button_SaveAlbumName
            // 
            this.button_SaveAlbumName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_SaveAlbumName.Location = new System.Drawing.Point(134, 2);
            this.button_SaveAlbumName.Margin = new System.Windows.Forms.Padding(2);
            this.button_SaveAlbumName.Name = "button_SaveAlbumName";
            this.button_SaveAlbumName.Size = new System.Drawing.Size(50, 38);
            this.button_SaveAlbumName.TabIndex = 4;
            this.button_SaveAlbumName.Text = "保存";
            this.button_SaveAlbumName.UseVisualStyleBackColor = true;
            this.button_SaveAlbumName.Click += new System.EventHandler(this.button_SaveAlbumName_Click);
            // 
            // textBox_SaveAlbumName
            // 
            this.textBox_SaveAlbumName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SaveAlbumName.Location = new System.Drawing.Point(40, 2);
            this.textBox_SaveAlbumName.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SaveAlbumName.Multiline = true;
            this.textBox_SaveAlbumName.Name = "textBox_SaveAlbumName";
            this.textBox_SaveAlbumName.Size = new System.Drawing.Size(90, 38);
            this.textBox_SaveAlbumName.TabIndex = 3;
            // 
            // b004
            // 
            this.b004.AutoSize = true;
            this.b004.Dock = System.Windows.Forms.DockStyle.Right;
            this.b004.Location = new System.Drawing.Point(32, 60);
            this.b004.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.b004.Name = "b004";
            this.b004.Size = new System.Drawing.Size(128, 61);
            this.b004.TabIndex = 2;
            this.b004.Text = "現在のスライドショーをアルバムとして保存";
            this.b004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton_AlbumSlideShow
            // 
            this.radioButton_AlbumSlideShow.AutoSize = true;
            this.radioButton_AlbumSlideShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_AlbumSlideShow.Location = new System.Drawing.Point(42, 2);
            this.radioButton_AlbumSlideShow.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_AlbumSlideShow.Name = "radioButton_AlbumSlideShow";
            this.radioButton_AlbumSlideShow.Size = new System.Drawing.Size(133, 32);
            this.radioButton_AlbumSlideShow.TabIndex = 1;
            this.radioButton_AlbumSlideShow.TabStop = true;
            this.radioButton_AlbumSlideShow.Text = "保存済みのアルバム";
            this.radioButton_AlbumSlideShow.UseVisualStyleBackColor = true;
            this.radioButton_AlbumSlideShow.CheckedChanged += new System.EventHandler(this.radioButton_AlbumSlideShow_CheckedChanged);
            // 
            // radioButton_ListViewSlideShow
            // 
            this.radioButton_ListViewSlideShow.AutoEllipsis = true;
            this.radioButton_ListViewSlideShow.AutoSize = true;
            this.radioButton_ListViewSlideShow.Checked = true;
            this.radioButton_ListViewSlideShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton_ListViewSlideShow.Location = new System.Drawing.Point(43, 60);
            this.radioButton_ListViewSlideShow.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_ListViewSlideShow.Name = "radioButton_ListViewSlideShow";
            this.radioButton_ListViewSlideShow.Size = new System.Drawing.Size(129, 33);
            this.radioButton_ListViewSlideShow.TabIndex = 0;
            this.radioButton_ListViewSlideShow.TabStop = true;
            this.radioButton_ListViewSlideShow.Text = "リストビュー";
            this.radioButton_ListViewSlideShow.UseVisualStyleBackColor = true;
            this.radioButton_ListViewSlideShow.CheckedChanged += new System.EventHandler(this.radioButton_ListViewSlideShow_CheckedChanged);
            // 
            // button_StartSlideShow
            // 
            this.button_StartSlideShow.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_StartSlideShow.Location = new System.Drawing.Point(593, 2);
            this.button_StartSlideShow.Margin = new System.Windows.Forms.Padding(10, 2, 2, 2);
            this.button_StartSlideShow.Name = "button_StartSlideShow";
            this.button_StartSlideShow.Size = new System.Drawing.Size(41, 46);
            this.button_StartSlideShow.TabIndex = 5;
            this.button_StartSlideShow.Text = "▶";
            this.button_StartSlideShow.UseVisualStyleBackColor = true;
            this.button_StartSlideShow.Click += new System.EventHandler(this.button_StartSlideShow_Click);
            // 
            // button_Pause_SlideShow
            // 
            this.button_Pause_SlideShow.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Pause_SlideShow.Location = new System.Drawing.Point(396, 2);
            this.button_Pause_SlideShow.Margin = new System.Windows.Forms.Padding(2);
            this.button_Pause_SlideShow.Name = "button_Pause_SlideShow";
            this.button_Pause_SlideShow.Size = new System.Drawing.Size(41, 46);
            this.button_Pause_SlideShow.TabIndex = 4;
            this.button_Pause_SlideShow.Text = "||";
            this.button_Pause_SlideShow.UseVisualStyleBackColor = true;
            this.button_Pause_SlideShow.Click += new System.EventHandler(this.button_Pause_Click);
            // 
            // button_StopSlideShow
            // 
            this.button_StopSlideShow.Location = new System.Drawing.Point(2, 2);
            this.button_StopSlideShow.Margin = new System.Windows.Forms.Padding(2, 2, 10, 2);
            this.button_StopSlideShow.Name = "button_StopSlideShow";
            this.button_StopSlideShow.Size = new System.Drawing.Size(41, 46);
            this.button_StopSlideShow.TabIndex = 3;
            this.button_StopSlideShow.UseVisualStyleBackColor = true;
            this.button_StopSlideShow.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_Back
            // 
            this.button_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Back.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Back.Location = new System.Drawing.Point(2, 134);
            this.button_Back.Margin = new System.Windows.Forms.Padding(2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(137, 62);
            this.button_Back.TabIndex = 1;
            this.button_Back.Text = "◀";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // pictureBox_SlideShow
            // 
            this.pictureBox_SlideShow.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_SlideShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_SlideShow.ImageLocation = "";
            this.pictureBox_SlideShow.Location = new System.Drawing.Point(149, 2);
            this.pictureBox_SlideShow.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_SlideShow.Name = "pictureBox_SlideShow";
            this.pictureBox_SlideShow.Size = new System.Drawing.Size(519, 334);
            this.pictureBox_SlideShow.TabIndex = 0;
            this.pictureBox_SlideShow.TabStop = false;
            // 
            // timer_SlideShow
            // 
            this.timer_SlideShow.Interval = 3000;
            this.timer_SlideShow.Tick += new System.EventHandler(this.timer_SlideShow_Tick);
            // 
            // button_Next
            // 
            this.button_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Next.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Next.Location = new System.Drawing.Point(2, 134);
            this.button_Next.Margin = new System.Windows.Forms.Padding(2);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(101, 62);
            this.button_Next.TabIndex = 2;
            this.button_Next.Text = "▶";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(991, 489);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel8, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel9, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.89552F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.91045F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.832298F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.294F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.84058F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.902692F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(192, 483);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(201, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.39304F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.60697F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(787, 483);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.46988F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.53012F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel4.Controls.Add(this.button_StopSlideShow, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_Pause_SlideShow, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_StartSlideShow, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 347);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(781, 133);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.02381F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.97619F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel5.Controls.Add(this.pictureBox_SlideShow, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel11, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(781, 338);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Size = new System.Drawing.Size(600, 314);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.45679F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.54321F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel6.Controls.Add(this.radioButton_ListViewSlideShow, 1, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.38614F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.61386F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(186, 95);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.8169F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.1831F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel7.Controls.Add(this.radioButton_AlbumSlideShow, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.comboBox_AlbumName, 1, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 104);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.56962F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.43038F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(186, 80);
            this.tableLayoutPanel7.TabIndex = 7;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.51852F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.48148F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel8.Controls.Add(this.b004, 1, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 223);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(186, 121);
            this.tableLayoutPanel8.TabIndex = 8;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.09091F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.90909F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel9.Controls.Add(this.button_SaveAlbumName, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.textBox_SaveAlbumName, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 350);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(186, 85);
            this.tableLayoutPanel9.TabIndex = 9;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.button_Back, 0, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 3;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(141, 332);
            this.tableLayoutPanel10.TabIndex = 3;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.button_Next, 0, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(673, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 3;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(105, 332);
            this.tableLayoutPanel11.TabIndex = 4;
            // 
            // SlideShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 489);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SlideShow";
            this.Text = "SldeShow";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SlideShow)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox_SlideShow;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.RadioButton radioButton_AlbumSlideShow;
        private System.Windows.Forms.RadioButton radioButton_ListViewSlideShow;
        private System.Windows.Forms.Label b004;
        private System.Windows.Forms.Button button_SaveAlbumName;
        private System.Windows.Forms.TextBox textBox_SaveAlbumName;
        private System.Windows.Forms.Button button_StartSlideShow;
        private System.Windows.Forms.Button button_Pause_SlideShow;
        private System.Windows.Forms.Button button_StopSlideShow;
        private System.Windows.Forms.ComboBox comboBox_AlbumName;
        private System.Windows.Forms.Timer timer_SlideShow;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
    }
}