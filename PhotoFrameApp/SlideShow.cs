using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoFrame.Domain.Model;
using PhotoFrame.Application;

namespace PhotoFrameApp
{
    public partial class SlideShow : Form
    {

        private IEnumerable<PhotoFrame.Domain.Model.Photo> photo_listview;//リストビュー上のフォト
        private IEnumerable<PhotoFrame.Domain.Model.Photo> slideshow_list;//スライドショーを行う写真リスト

        private IEnumerable<Album> albumlist;
        private PhotoFrameApplication application;
        private int slideindex;

        public SlideShow(IEnumerable<PhotoFrame.Domain.Model.Photo> photolist, PhotoFrameApplication application )
        {
            InitializeComponent();

            this.photo_listview = photolist;
            this.slideshow_list = photolist;
            
            this.application = application;
            this.albumlist = application.GetAllAlbums();
            this.slideindex = 0;
            pictureBox_SlideShow.ImageLocation = this.slideshow_list.ElementAt(slideindex).File.FilePath;

            timer_SlideShow.Interval = 3000;

            //アルバムリストの一時的な初期値の設定
            Album album1 = new Album("abc", "test1", "test説明");
            Album album2 = new Album("def", "test2", "test1説明");
            Album album3 = new Album("ghi", "test3", "test2説明");

            List<Album> list = new List<Album>();
            list.Add(album1);
            list.Add(album2);
            list.Add(album3);

            this.albumlist = list;

            foreach (var albums in this.albumlist)
            {
                comboBox_AlbumName.Items.Add(albums.Name);
            }

        }

        /// <summary>
        /// 「保存済みのアルバム」のラジオボタンが変化したら
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_AlbumSlideShow_CheckedChanged(object sender, EventArgs e)
        {
            this.slideindex = 0;

            if (radioButton_AlbumSlideShow.Checked == true)
            {//「保存済みのアルバム」のラジオボタンのチェックが入ったとき
                comboBox_AlbumName.Enabled = true;
                radioButton_ListViewSlideShow.Checked = false;
            }
            //else
            //{//「リストビューの」ラジオボタンのチェックが入ったとき
            //        comboBox_AlbumName.Enabled = false;
            //}
        }


        /// <summary>
        /// 「リストビュー」のラジオボタンが変化したら
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_ListViewSlideShow_CheckedChanged(object sender, EventArgs e)
        {
            this.slideindex = 0;
            if (radioButton_ListViewSlideShow.Checked == true)
            {//「リストビューの」ラジオボタンのチェックが入ったとき
                this.slideshow_list = this.photo_listview;
                comboBox_AlbumName.Enabled = false;
                radioButton_AlbumSlideShow.Checked = false;
            }
            //else
            //{//「保存済みのアルバム」のラジオボタンのチェックが入ったとき
            //    comboBox_AlbumName.Enabled = true;
            //    radioButton_AlbumSlideShow.Checked=
            //}
        }

        /// <summary>
        /// コンボボックスのアルバム名が変わると、slideshow_listを更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_AlbumName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///lリストを初期化する必要はある？？　
            this.slideshow_list = application.SearchAlbum(comboBox_AlbumName.Text);
        }

        /// <summary>
        /// スライドショーにアルバム名を付けて保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SaveAlbumName_Click(object sender, EventArgs e)
        {
            string savaName = textBox_SaveAlbumName.Text;
            //var list = (from p in this.albumlist where p.Name == savaName select p).ToList();

            bool saveSuccess = application.AddAlbum(savaName, this.slideshow_list);

            if (saveSuccess ==true)
            {
                MessageBox.Show($"{savaName}というアルバム名で保存しました。");
                comboBox_AlbumName.Items.Add(savaName);

            }
            else
            {
                MessageBox.Show("すでに保存されているアルバム名です。");

            }

        }

        /// <summary>
        /// 再生ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_StartSlideShow_Click(object sender, EventArgs e)
        {
            button_StartSlideShow.Enabled = false;
            button_Pause_SlideShow.Enabled = true;
            button_StopSlideShow.Enabled = true;
            timer_SlideShow.Start();
        }

        /// <summary>
        /// 一時停止ボタンが押されとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Pause_Click(object sender, EventArgs e)
        {
            timer_SlideShow.Stop();
            button_StartSlideShow.Enabled = true;
            button_Pause_SlideShow.Enabled = false;
            button_StopSlideShow.Enabled = true;
        }

        /// <summary>
        /// 停止ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Stop_Click(object sender, EventArgs e)
        {
            timer_SlideShow.Stop();
            slideindex = 0;
            button_StartSlideShow.Enabled = true;
            button_Pause_SlideShow.Enabled = true;
            button_StopSlideShow.Enabled = false;
        }

        /// <summary>
        /// 「Back」ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Back_Click(object sender, EventArgs e)
        {

            if (this.slideindex > 0)
            {
                slideindex--;
                pictureBox_SlideShow.ImageLocation = this.slideshow_list.ElementAt(slideindex).File.FilePath;

            }
        }

        /// <summary>
        /// 「Next」ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Next_Click(object sender, EventArgs e)
        {
            if (this.slideindex < slideshow_list.Count() - 1)
            {
                slideindex++;
                pictureBox_SlideShow.ImageLocation = this.slideshow_list.ElementAt(slideindex).File.FilePath;
            }
        }

        /// <summary>
        /// スライドショーを行う。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_SlideShow_Tick(object sender, EventArgs e)
        {
            slideindex++;

            if (slideindex >= slideshow_list.Count())
            {
                slideindex = 0;
            }

            pictureBox_SlideShow.ImageLocation = this.slideshow_list.ElementAt(slideindex).File.FilePath;


        }

       
    }
}
