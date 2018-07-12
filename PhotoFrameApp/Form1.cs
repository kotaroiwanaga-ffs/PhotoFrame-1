using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoFrame.Application;
using PhotoFrame.Domain;
using PhotoFrame.Domain.Model;
using PhotoFrame.Domain.UseCase;
using PhotoFrame.Persistence;
using PhotoFrame.Persistence.Csv;
using System.IO;
using System.Threading;

namespace PhotoFrameApp
{
    public partial class Form1 : Form
    {
        private bool isFavorite_F_now;
        private bool isFavorite_RD_now;
        private string filepath;
        private DateTime date_S;
        private DateTime date_E;


        Photo a;
        Photo b;
        Photo c;

        IEnumerable<Photo> searchedPhotos;
        //private IPhotoRepository photoRepository;
        //private IAlbumRepository albumRepository;
        //private IPhotoFileService photoFileService;
        //private PhotoFrameApplication application;
        //private IEnumerable<Photo> searchedPhotos; // リストビュー上のフォトのリスト

        //private bool flagAsync;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            isFavorite_F_now = false;
            isFavorite_RD_now = false;
            filepath = "";
            date_S = DateTime.Now;
            date_E = DateTime.Now;

            a = new Photo(@"C:\研修用\Album1\Chrysanthemum.jpg", true, new DateTime(),null);
            b = new Photo(@"C:\研修用\Album1\Desert.jpg", false, new DateTime(),null);
            c = new Photo(@"C:\研修用\Album1\Hydrangeas.jpg", true, DateTime.Now, null);

            Photo[] photos = { a, b, c };
            searchedPhotos =  photos.AsEnumerable<Photo>();

            //// 各テストごとにデータベースファイルを削除
            //// (35-42をコメントアウトしても動きます)
            //if (System.IO.File.Exists("_Photo.csv"))
            //{
            //    System.IO.File.Delete("_Photo.csv");
            //}
            //if (System.IO.File.Exists("_Album.csv"))
            //{
            //    System.IO.File.Delete("_Album.csv");
            //}

            //// メンバ変数初期化
            //RepositoryFactory repositoryFactory = new RepositoryFactory(PhotoFrame.Persistence.Type.Csv);
            //ServiceFactory serviceFactory = new ServiceFactory(); 
            //photoRepository = repositoryFactory.PhotoRepository;
            //albumRepository = repositoryFactory.AlbumRepository;
            //photoFileService = serviceFactory.PhotoFileService;
            //application = new PhotoFrameApplication(albumRepository, photoRepository, photoFileService);
            //searchedPhotos = new List<Photo>().AsEnumerable();

            //flagAsync = false;

            //// 全アルバム名を取得し、アルバム変更リストをセット
            //IEnumerable<Album> allAlbums = albumRepository.Find((IQueryable<Album> albums) => albums);

            //if(allAlbums != null)
            //{
            //    foreach (Album album in allAlbums)
            //    {
            //        comboBox_ChangeAlbum.Items.Add(album.Name);
            //    }
            //}

        }

        ///// <summary>
        ///// アルバム名でフォトを検索
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void button_Search_Click(object sender, EventArgs e)
        //{
        //    if (!CheckFlag())
        //    {
        //        flagAsync = true;

        //        if (radioButton_AlbumName.Checked)
        //        {
        //            this.searchedPhotos = await application.SearchAlbumAsync(textBox_Search.Text);
        //        }
        //        else if (radioButton_DirectoryName.Checked)
        //        {
        //            this.searchedPhotos = await application.SearchDirectoryAsync(textBox_Search.Text);
        //        }

        //        renewPhotoListView();

        //        flagAsync = false;
        //    }


        //}

        ///// <summary>
        ///// アルバム新規作成
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void button_CreateAlbum_Click(object sender, EventArgs e)
        //{
        //    if (!CheckFlag())
        //    {
        //        flagAsync = true;

        //        string albumName = textBox_CreateAlbum.Text;
        //        int result = await application.CreateAlbumAsync(albumName);

        //        switch (result)
        //        {
        //            case 0:
        //                comboBox_ChangeAlbum.Items.Add(albumName);
        //                break;
        //            case 1:
        //                MessageBox.Show("アルバム名が未入力です");
        //                break;
        //            case 2:
        //                MessageBox.Show("既存のアルバム名です");
        //                break;
        //            default:
        //                break;
        //        }

        //        flagAsync = false;
        //    }

        //}

        ///// <summary>
        ///// お気に入り切り替え
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void button_ToggleFavorite_Click(object sender, EventArgs e)
        //{
        //    if (!CheckFlag())
        //    {
        //        flagAsync = true;

        //        List<int> listviewIndexList = new List<int>();

        //        for (int i = 0; i < listView_PhotoList.SelectedItems.Count; i++)
        //        {
        //            listviewIndexList.Add(listView_PhotoList.SelectedItems[i].Index);
        //        }

        //        foreach (int index in listviewIndexList)
        //        {
        //            Photo photo = await application.ToggleFavoriteAsync(searchedPhotos.ElementAt(index));

        //            renewPhotoListViewItem(index, photo);
        //        }

        //        flagAsync = false;
        //    }

        //}

        ///// <summary>
        ///// 選択中のフォトの所属アルバムを変更
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void button_ChangeAlbum_Click(object sender, EventArgs e)
        //{
        //    if (!CheckFlag())
        //    {
        //        flagAsync = true;

        //        string newAlbumName = comboBox_ChangeAlbum.Text;
        //        List<int> listviewIndexList = new List<int>();

        //        for (int i = 0; i < listView_PhotoList.SelectedItems.Count; i++)
        //        {
        //            listviewIndexList.Add(listView_PhotoList.SelectedItems[i].Index);
        //        }

        //        foreach (int index in listviewIndexList)
        //        {
        //            Photo photo = await application.ChangeAlbumAsync(searchedPhotos.ElementAt(index), newAlbumName);

        //            renewPhotoListViewItem(index, photo);
        //        }

        //        flagAsync = false;
        //    }

        //}

        ///// <summary>
        ///// リストビュー上のフォトのスライドショーを実行
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void button_SlideShow_Click(object sender, EventArgs e)
        //{
        //    if(this.searchedPhotos.Count() > 0)
        //    {
        //        SlideShow slideShowForm = new SlideShow(this.searchedPhotos);
        //        slideShowForm.ShowDialog();
        //    }

        //}

        ///// <summary>
        ///// リストビュー1行分更新
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="photo"></param>
        //private void renewPhotoListViewItem(int index, Photo photo)
        //{
        //    string albumName, isFavorite;

        //    if (photo.Album != null)
        //    {
        //        albumName = photo.Album.Name;
        //    }
        //    else
        //    {
        //        albumName = "";
        //    }


        //    if (photo.IsFavorite)
        //    {
        //        isFavorite = "★";
        //    }
        //    else
        //    {
        //        isFavorite = "";
        //    }

        //    listView_PhotoList.Items[index].SubItems[0].Text = photo.File.FilePath;
        //    listView_PhotoList.Items[index].SubItems[1].Text = albumName;
        //    listView_PhotoList.Items[index].SubItems[2].Text = isFavorite;
        //}

        ///// <summary>
        ///// リストビューの更新
        ///// </summary>
        ///// <param name="photos"></param>
        //private void renewPhotoListView()
        //{
        //    listView_PhotoList.Items.Clear();

        //    if (this.searchedPhotos != null)
        //    {
        //        foreach (Photo photo in searchedPhotos)
        //        {
        //            string albumName, isFavorite;

        //            if(photo.Album != null)
        //            {
        //                albumName = photo.Album.Name;
        //            }
        //            else
        //            {
        //                albumName = "";
        //            }


        //            if (photo.IsFavorite)
        //            {
        //                isFavorite = "★";
        //            }
        //            else
        //            {
        //                isFavorite = "";
        //            }

        //            string[] item = { photo.File.FilePath, albumName, isFavorite };
        //            listView_PhotoList.Items.Add(new ListViewItem(item));

        //        }
        //    }
        //}

        ///// <summary>
        ///// バックグラウンド処理中かの判定
        ///// </summary>
        ///// <param name="query"></param>
        //private bool CheckFlag()
        //{
        //    if (!flagAsync)
        //    {
        //        return flagAsync;
        //    }
        //    else
        //    {
        //        MessageBox.Show("処理中です");
        //        return flagAsync;
        //    }
        //}

        private void renewPhotoListView()
        {
            photoListView.Items.Clear();

            if (this.searchedPhotos != null)
            {
                foreach (Photo photo in searchedPhotos)
                {
                    string isFavorite;


                    if (photo.isFavorite)
                    {
                        isFavorite = "★";
                    }
                    else
                    {
                        isFavorite = "";
                    }

                    string[] item = { Path.GetFileName(photo.filepath), isFavorite ,photo.date.ToString()};
                    photoListView.Items.Add(new ListViewItem(item));

                }
            }
        }


            /// <summary>
            /// ファイルボタンを押したとき
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void fileIcon_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            //fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            fbd.SelectedPath = @"C:\Windows";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                filepath = fbd.SelectedPath;
                filePathView.Text = (filepath);
            }
        }
        /// <summary>
        /// 日付指定ボタンのチェックが変更されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(dateCheckBox.Checked==true)
            {
                dateStart.Enabled = true;
                dateEnd.Enabled = true;
            }
            else
            {
                dateStart.Enabled = false;
                dateEnd.Enabled = false;
            }
        }
        /// <summary>
        /// 上のほうの星がクリックされたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isFavorite_F_Click(object sender, EventArgs e)
        {
            if(isFavorite_F_now==true)
            {
                isFavorite_F_now = false;
                isFavorite_F.ForeColor = Color.Gray;
            }
            else
            {
                isFavorite_F_now = true;
                isFavorite_F.ForeColor = Color.Yellow;
            }
        }
        /// <summary>
        /// 下のほうの星がクリックされたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isFavorite_RD_Click(object sender, EventArgs e)
        {
            if (isFavorite_RD_now == true)
            {
                isFavorite_RD_now = false;
                isFavorite_RD.ForeColor = Color.Gray;
            }
            else
            {
                isFavorite_RD_now = true;
                isFavorite_RD.ForeColor = Color.Yellow;
            }
        }
        /// <summary>
        /// 日付指定始まりを変更したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            date_S = dateStart.Value;
        }

        /// <summary>
        /// 日付指定終わりを変更したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            date_E = dateEnd.Value;

        }

        /// <summary>
        /// 検索ボタン押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            //searchedFolda = SearchFolda(filepath);
            renewPhotoListView();
        }

        /// <summary>
        /// リストビューの行が選択されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void photoListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //testlabel.Text = photoListView.SelectedItems.Count.ToString();
            if(photoListView.SelectedItems.Count==0)
            {

            }
            else if(photoListView.SelectedItems.Count == 1)
            {
                testlabel.Text = photoListView.SelectedItems[0].Text;
            }
            else
            {
                testlabel.Text = "複数選択してるよ";
            }
            
        }

        /// <summary>
        /// スライドショー呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slideShowButton_Click(object sender, EventArgs e)
        {
            //SlideShow slideShowForm = new SlideShow(this.searchedPhotos,application);
            //slideShowForm.ShowDialog();
        }
    }

    /// <summary>
    /// テスト用
    /// </summary>
    public class Photo
    {
        public string filepath;
        public bool isFavorite;
        public DateTime date;
        public string[] keyword;

        public Photo(string a,bool b ,DateTime c,string[] d)
        {
            filepath = a;
            isFavorite = b;
            date = c;
            keyword = d;
        }
    }
}
