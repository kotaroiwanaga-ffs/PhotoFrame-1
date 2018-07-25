using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;


namespace PhotoFrame.Domain.UseCase
{
    public class SearchFolder
    {
        private readonly RepositoryMaster repositoryMaster;
        private readonly IPhotoFileService photoFileService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="repositoryMaster"></param>
        /// <param name="photoFileService"></param>
        public SearchFolder(RepositoryMaster repositoryMaster, IPhotoFileService photoFileService)
        {
            this.repositoryMaster = repositoryMaster;
            this.photoFileService = photoFileService;
        }

        /// <summary>
        /// 指定したフォルダパス配下の画像ファイルをPhoto型に変換してリストで返す
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(string folderPath)
        {
            List<Photo> photos = new List<Photo>();

            // folderPath配下にあるすべての画像ファイルパスを取得
            IEnumerable<File> files = photoFileService.FindAllPhotoFilesFromDirectory(folderPath);

            // ファイルパスの数が100以下の時のみPhoto型変換を行う
            if(files.Count() <= 100)
            {
                foreach (File file in files)
                {
                    Func<IQueryable<Photo>, Photo> query = ((folderPhotos) =>
                    {
                        return folderPhotos
                            .Where(p => p.File.FilePath == file.FilePath)
                            .FirstOrDefault();
                    });

                    // 保存済みファイルパスだったか
                    Photo hitPhoto = repositoryMaster.FindPhoto(query);

                    // 保存済みの画像だった場合
                    if (hitPhoto != null)
                    {
                        // 画像ファイルの撮影日時取得を試みることでデータ破損がないか確認
                        if (GetFilmingDate(file.FilePath) != null)
                        {
                            photos.Add(hitPhoto);
                        }
                    }
                    // 未保存の画像だった場合
                    else
                    {
                        // 画像ファイルから撮影日時を取得
                        DateTime? date = GetFilmingDate(file.FilePath);

                        if (date != null)
                        {
                            photos.Add(new Photo(file, (DateTime)date));
                        }
                    }
                }

                // フォルダ検索の結果できたPhotoのリストをrepositoryMasterに保存させておく
                this.repositoryMaster.SetAllPhotos(photos);
            }

            return photos;
        }

        // 画像から撮影日時を取得
        private DateTime? GetFilmingDate(string filePath)
        {
            System.IO.FileStream stream = System.IO.File.OpenRead(filePath);
            Image image;

            try
            {
                image = Image.FromStream(stream, false, false);
            }
            catch (Exception)
            {
                return null; // データが破損していた場合
            }

            DateTime date = new DateTime();

            // 撮影日時取得を試みる
            foreach (PropertyItem item in image.PropertyItems)
            {
                if (item.Id == 0x9003 && item.Type == 2)
                {
                    string val = System.Text.Encoding.ASCII.GetString(item.Value);
                    val = val.Trim(new char[] { '\0' });
                    date = DateTime.ParseExact(val, "yyyy:MM:dd HH:mm:ss", null);
                }
            }

            if (date != null)
            {
                return date; // 撮影日時が取得できた場合
            }
            else
            {
                return new DateTime(); // 撮影日時が設定されていなかった場合
            }
        }

    }
}
