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
        private List<string> pullDownKeyword;
        private int selectNumber;
        private List<int> selectNumbers;
        private Photo selectedPhoto;
        private IEnumerable<Photo> searchedPhotos;
        private bool sortUpDown;
       // private List<string> inputKeyword;

        //private PhotoFrameApplication application;
        private PhotoFrameApplicationTest application;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            //var application = new PhotoFrameApplication();
            application = new PhotoFrameApplicationTest();
            // this.application = application;

            isFavorite_F_now = false;
            isFavorite_RD_now = false;
            filepath = "";
            date_S = DateTime.Now;
            date_E = DateTime.Now;
            pullDownKeyword = new List<string>();

            selectNumber = -1;
         
            sortUpDown = false;
            //inputKeyword = null;

        }

        /// <summary>
        /// リストビュー全行更新
        /// </summary>
        private void renewPhotoListView()
        {
            photoListView.Items.Clear();
            DateTime nullDate = new DateTime();

            if (this.searchedPhotos != null)
            {
                pullDownKeyword = new List<string>();
                foreach (Photo photo in searchedPhotos)
                {
                    string isFavorite;
                    string dateTime;

                    if (photo.IsFavorite)
                    {
                        isFavorite = "★";
                    }
                    else
                    {
                        isFavorite = "";
                    }

                    //DateTimeが初期値なら表示しない
                    if (photo.Date == nullDate)
                    {
                        dateTime = "";
                    }
                    else
                    {
                        dateTime = photo.Date.ToString();
                    }

                    string[] item = { Path.GetFileName(photo.File.FilePath), isFavorite, dateTime };
                    photoListView.Items.Add(new ListViewItem(item));

                    pullDownKeyword.AddRange(photo.Keywords);
                }
                renewPullDownKeyword();
            }
        }

        /// <summary>
        /// リストビュー１行更新
        /// </summary>
        /// <param name="index"></param>
        /// <param name="photo"></param>
        private void renewPhotoListViewItem(int index, Photo photo)
        {
            DateTime nullDate = new DateTime();
            string isFavorite;
            string dateTime;

            if (photo.IsFavorite)
            {
                isFavorite = "★";
            }
            else
            {
                isFavorite = "";
            }

            //DateTimeが初期値なら表示しない
            if (photo.Date == nullDate)
            {
                dateTime = "";
            }
            else
            {
                dateTime = photo.Date.ToString();
            }

            photoListView.Items[index].SubItems[0].Text = Path.GetFileName(photo.File.FilePath);
            photoListView.Items[index].SubItems[1].Text = isFavorite;
            photoListView.Items[index].SubItems[2].Text = dateTime;

            pullDownKeyword = new List<string>();
            foreach (Photo pho in searchedPhotos)
            {
                pullDownKeyword.AddRange(pho.Keywords);
            }
            renewPullDownKeyword();
        }

        /// <summary>
        /// キーワードのプルダウンの中身を更新
        /// </summary>
        private void renewPullDownKeyword()
        {
            selectKeyword_F.Items.Clear();
            selectKeyword_RD.Items.Clear();
            pullDownKeyword = (from key in pullDownKeyword select key).Distinct().ToList();
            foreach (string key in pullDownKeyword)
            {
                selectKeyword_F.Items.Add(key);
                selectKeyword_RD.Items.Add(key);
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
            if (dateCheckBox.Checked == true)
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
            //フィルタに使うお気に入りの条件を反転させる
            if (isFavorite_F_now == true)
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
            //★の色変え
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

            //何個選択されているかで場合分けして、リストを更新する
            if (photoListView.SelectedItems.Count == 0)
            {

            }
            else if (photoListView.SelectedItems.Count == 1)
            {
                //参照を渡しているのでrenewすると表示が変わる
                selectNumber = photoListView.SelectedItems[0].Index;
                selectedPhoto = searchedPhotos.ElementAt(selectNumber);
                List<Photo> tmpPhotos = new List<Photo>();
                tmpPhotos.Add(selectedPhoto);
                application.ToggleIsFavorite(tmpPhotos.AsEnumerable());
                renewPhotoListViewItem(selectNumber, selectedPhoto);
            }
            else
            {
                selectNumbers = new List<int>();
                List<Photo> selectedPhotos = new List<Photo>();
                for (int i = 0; i < photoListView.SelectedItems.Count; i++)
                {
                    selectNumber = photoListView.SelectedItems[i].Index;
                    selectedPhotos.Add(searchedPhotos.ElementAt(selectNumber));
                    selectNumbers.Add(selectNumber);

                }
                application.ToggleIsFavorite(selectedPhotos.AsEnumerable());
                foreach(int renewNumber in selectNumbers)
                {
                    renewPhotoListViewItem(renewNumber, searchedPhotos.ElementAt(renewNumber));
                }
            }
        }

        /// <summary>
        /// 日付指定始まりを変更したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            //日付始まりを設定
            date_S = dateStart.Value;
        }

        /// <summary>
        /// 日付指定終わりを変更したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            //日付終わりを設定
            date_E = dateEnd.Value;
        }

        /// <summary>
        /// 検索ボタン押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            //検索する
            searchedPhotos = application.SearchFolder(filepath);
            if (searchedPhotos.Count() == 0)
            {
                MessageBox.Show("指定したフォルダには画像がありませんでした。またはアクセス権がありませんでした。");
            }
            else
            {
                renewPhotoListView();
            }
        }

        /// <summary>
        /// リストビューの行が選択されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void photoListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //リストビューの行が何行選択されているかで場合分け
            if (photoListView.SelectedItems.Count == 0)
            {
                //０枚のときは処理なし
            }
            else if (photoListView.SelectedItems.Count == 1)
            {
                //１枚選択のとき、プレビューに画像とキーワード表示
                selectNumber = photoListView.SelectedItems[0].Index;
                selectedPhoto = searchedPhotos.ElementAt(selectNumber);
                photoPreview.ImageLocation = selectedPhoto.File.FilePath;
                if (selectedPhoto.Keywords != null)
                {
                    photoKeyword.Text = string.Join(",", selectedPhoto.Keywords);
                }
                else
                {
                    photoKeyword.Text = "";
                }

                isFavorite_RD_now = selectedPhoto.IsFavorite;
                if (isFavorite_RD_now == true)
                {
                    isFavorite_RD.ForeColor = Color.Yellow;
                }
                else
                {
                    isFavorite_RD.ForeColor = Color.Gray;
                }
            }
            else
            {
                //２枚以上のときの処理
                photoPreview.ImageLocation = @"C:\研修用\複数選択してるよ.png";
                photoKeyword.Text = "";
                isFavorite_RD_now = false;
                isFavorite_RD.ForeColor = Color.Gray;
            }

        }

        /// <summary>
        /// スライドショーを押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slideShowButton_Click(object sender, EventArgs e)
        {

            //スライドショーを開く

            //SlideShow slideShowForm = new SlideShow(searchedPhotos, application);
           // slideShowForm.ShowDialog();
        }

        /// <summary>
        /// フィルタボタンを押した時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterButton_Click(object sender, EventArgs e)
        {
            string filterKeyword;
            DateTime filterDateS;
            DateTime filterDateE;
            //画像があるかどうか
            if (searchedPhotos.Count() == 0)
            {
                //キーワードが選択されているか
                if (selectKeyword_F.SelectedItem == null)
                {
                    filterKeyword = null;
                }
                else
                {
                    filterKeyword = selectKeyword_F.SelectedItem.ToString();
                }

                //日付指定をフィルタに使うかどうか
                if (dateCheckBox.Checked == true)
                {
                    int result = dateEnd.Value.Date.CompareTo(dateStart.Value.Date);
                    //日付指定が正しく行われているか
                    if (result == 1)
                    {
                        filterDateS = dateStart.Value.Date;
                        filterDateE = dateEnd.Value.Date;
                        searchedPhotos = application.Filter(filterKeyword, isFavorite_F_now, filterDateS, filterDateE);
                        renewPhotoListView();
                    }
                    else
                    {
                        MessageBox.Show("日付の設定が間違っています。左のボックスに古い日付を指定してください。");
                    }
                }
                else
                {
                    filterDateS = new DateTime();
                    filterDateE = new DateTime();
                    //フィルタ条件がすべてない場合、今までのフィルタを解除
                    if (isFavorite_F_now == false && filterKeyword == null)
                    {
                        searchedPhotos = application.SearchFolder(filepath);
                    }
                    else
                    {
                        searchedPhotos = application.Filter(filterKeyword, isFavorite_F_now, filterDateS, filterDateE);
                    }
                    renewPhotoListView();
                }
            }
            else
            {
                MessageBox.Show("フィルタする対象画像がありません。");
            }
        }

        /// <summary>
        /// リストビューの撮影日時を押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void photoListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //撮影日時の文字を押したときだけ
            if (e.Column == 2)
            {
                //昇順降順を切り替え
                if (sortUpDown == true)
                {
                    sortUpDown = false;
                    searchedPhotos = application.SortDateAscending(searchedPhotos);
                }
                else
                {
                    sortUpDown = true;
                    searchedPhotos = application.SortDateDescending(searchedPhotos);
                }
                renewPhotoListView();
            }
            else
            {
                //なにもしない
            }
        }

        /// <summary>
        /// 登録ボタンを押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerButton_Click(object sender, EventArgs e)
        {
            //何個選択されているかで場合分けして、リストを更新する
            if (photoListView.SelectedItems.Count == 0)
            {

            }
            else if (photoListView.SelectedItems.Count == 1)
            {
                //参照を渡しているのでsearchedPhotoを更新すると全部変わる
                selectNumber = photoListView.SelectedItems[0].Index;
                selectedPhoto = searchedPhotos.ElementAt(selectNumber);
                List<Photo> tmpPhotos = new List<Photo>();
                tmpPhotos.Add(selectedPhoto);
                //AddKeywordが成功するかどうか
                if (application.AddKeyword(selectKeyword_RD.Text, tmpPhotos))
                {
                    renewPhotoListViewItem(selectNumber, selectedPhoto);
                    if (selectedPhoto.Keywords != null)
                    {
                        photoKeyword.Text = string.Join(",", tmpPhotos[0].Keywords);
                    }
                    else
                    {
                        photoKeyword.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("キーワードの追加に失敗しました。");
                }
            }
            else
            {
                List<Photo> selectedPhotos = new List<Photo>();
                for (int i = 0; i < photoListView.SelectedItems.Count; i++)
                {
                    selectedPhotos.Add(searchedPhotos.ElementAt(photoListView.SelectedItems[i].Index));
                }
                if (application.AddKeyword(selectKeyword_RD.Text, selectedPhotos.AsEnumerable()))
                {
                    renewPhotoListView();
                }
                else
                {
                    MessageBox.Show("キーワードの追加に失敗しました。");
                }
            }
        }

        /// <summary>
        /// 削除ボタンを押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //何個選択されているかで場合分けして、リストを更新する
            if (photoListView.SelectedItems.Count == 0)
            {

            }
            else if (photoListView.SelectedItems.Count == 1)
            {
                //参照を渡しているのでrenewすると表示が変わる
                selectNumber = photoListView.SelectedItems[0].Index;
                selectedPhoto = searchedPhotos.ElementAt(selectNumber);
                List<Photo> tmpPhotos = new List<Photo>();
                tmpPhotos.Add(selectedPhoto);
                if (application.DeleteKeyword(selectKeyword_RD.Text, tmpPhotos))
                {
                    renewPhotoListViewItem(selectNumber, selectedPhoto);
                    if (selectedPhoto.Keywords != null)
                    {
                        photoKeyword.Text = string.Join(",", selectedPhoto.Keywords);
                    }
                    else
                    {
                        photoKeyword.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("キーワードの削除に失敗しました。");
                }
            }
            else
            {
                List<Photo> selectedPhotos = new List<Photo>();
                for (int i = 0; i < photoListView.SelectedItems.Count; i++)
                {
                    selectedPhotos.Add(searchedPhotos.ElementAt(photoListView.SelectedItems[i].Index));
                }
                if (application.DeleteKeyword(selectKeyword_RD.Text, selectedPhotos.AsEnumerable()))
                {
                    renewPhotoListView();
                }
                else
                {
                    MessageBox.Show("キーワードの削除に失敗しました。");
                }
            }
        }
    }

}
