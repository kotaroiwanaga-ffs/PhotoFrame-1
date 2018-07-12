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
        private IEnumerable<Photo> photolist_listview;//リストビュー上のフォト
        private IEnumerable<Album> albumlist;
        private PhotoFrameApplication application;

        public SlideShow(IEnumerable<Photo> photolist, PhotoFrameApplication application )
        {
            InitializeComponent();

            this.photolist_listview = photolist;
            
            this.application = application;
            this.albumlist = application.GetAllAlbums();


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

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

      

        private void radioButton_AlbumSlideShow_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_AlbumSlideShow.Checked == true)
            {
                comboBox_AlbumName.Enabled = true;
            }
            else
            {
                comboBox_AlbumName.Enabled = false;
            }
        }

        private void radioButton_ListViewSlideShow_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_AlbumSlideShow.Checked == true)
            {
                comboBox_AlbumName.Enabled = true;

            }
            else
            {
                comboBox_AlbumName.Enabled = false;
            }
        }

        private void button_SaveAlbumName_Click(object sender, EventArgs e)
        {
            string savaName = textBox_SaveAlbumName.Text;
            var list = (from p in this.albumlist where p.Name == savaName select p).ToList();

            if( list.Count != 0)
            {
                MessageBox.Show("すでに保存されたアルバム名です");
            }
            else
            {

            }
            
        }
    }
}
