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

namespace PhotoFrameApp
{
    public partial class SlideShow : Form
    {
        private IEnumerable<Photo> photolist_listview;//リストビュー上のフォト
        private IEnumerable<Album> albumlist;

        public SlideShow(IEnumerable<Photo> photolist)
        {
            this.photolist_listview = photolist;
            //this.albumlist = GetAllAlbums();
            InitializeComponent();




        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

      

        private void radioButton_AlbumSlideShow_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_AlbumSlideShow.Checked == true)
            {
                comboBox_AlbumName.Enabled = true;
                comboBox_AlbumName.Items.Add();
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
    }
}
