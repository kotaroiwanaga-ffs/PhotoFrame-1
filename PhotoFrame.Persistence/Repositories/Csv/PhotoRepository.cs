using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;


namespace PhotoFrame.Persistence.Csv
{
    /// <summary>
    /// <see cref="IPhotoRepository">の実装クラス
    /// </summary>
    public class PhotoRepository : IPhotoRepository
    {
        /// <summary>
        /// 永続化ストアとして利用するCSVファイルパス
        /// </summary>
        private string CsvFilePath { get; }
        private IAlbumRepository albumRepository;

        public PhotoRepository(string databaseName, IAlbumRepository albumRepository)
        {
            this.CsvFilePath = $"{databaseName}_Photo.csv"; // $"{...}" : 文字列展開
            this.albumRepository = albumRepository;
        }

        /// <summary>
        /// 用途不明(未使用)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Exists(Photo entity)
        {
            return FindBy(entity.Id) != null;
        }

        /// <summary>
        /// 指定したIDのフォトがあるか(未使用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistsBy(string id)
        {
            return FindBy(id) != null;
        }

        /// <summary>
        /// 検索条件(query)に該当するすべてのフォトを取得
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Find(Func<IQueryable<Photo>, IQueryable<Photo>> query)
        {

            IQueryable<Photo> allPhotos = FindAll();

            // Csvファイルがあった場合
            if (allPhotos != null)
            {
                return query(allPhotos);
            }
            // Csvファイルがない場合
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 検索条件(query)に該当するフォトを一つ分取得
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Photo Find(Func<IQueryable<Photo>, Photo> query)
        {
            IQueryable<Photo> allPhotos = FindAll();

            // Csvファイルがあった場合
            if (allPhotos != null)
            {
                return query(allPhotos);
            }
            // Csvファイルがない場合
            else
            {
                return null;
            }


        }

        /// <summary>
        /// IDの合致するフォトの取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Photo FindBy(string id)
        {
            IQueryable<Photo> allPhotos = FindAll();

            // Csvファイルがあった場合
            if (allPhotos != null)
            {
                for (int i = 0; i < allPhotos.Count(); i++)
                {
                    if (allPhotos.ElementAt(i).Id == id)
                    {
                        return allPhotos.ElementAt(i);
                    }
                }
            }

            // なかったよ
            return null;
        }

        /// <summary>
        /// フォトの更新・新規追加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Photo Store(Photo entity)
        {
            IQueryable<Photo> otherPhotos = FindAll(entity);

            using (StreamWriter sw = new StreamWriter(this.CsvFilePath))
            {
                // ファイルあった場合
                if (otherPhotos != null)
                {
                    // 既存のフォトデータの書き込み
                    foreach (Photo photo in otherPhotos)
                    {
                        sw.WriteLine(ToCsvString(photo));
                    }
                }

                // 新規フォトデータを書き込み
                sw.WriteLine(ToCsvString(entity));
            }

            return entity;
        }

        /// <summary>
        /// Csvファイル内のすべてのフォトの取得
        /// (引数にフォトを渡した場合はそのフォトと同じIDのフォトをリストから除く)
        /// </summary>
        /// <returns></returns>
        IQueryable<Photo> FindAll(Photo photo = null)
        {
            List<Photo> photos = new List<Photo>();

            if (System.IO.File.Exists(CsvFilePath))
            {
                using (StreamReader sr = new StreamReader(CsvFilePath, Encoding.UTF8))
                {
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        string[] photoData = line.Split(',');

                        Domain.Model.File file = new Domain.Model.File(photoData[1]);
                        Domain.Model.Album album = albumRepository.FindBy(photoData[3]);

                        if(photo == null || photo.Id != photoData[0])
                        {
                            photos.Add(new Photo(photoData[0], file, Convert.ToBoolean(photoData[2]), photoData[3], album));
                        }

                    }
                }

                return photos.AsQueryable();

            }
            else
            {
                // なかったよ
                return null;
            }
        }

        string ToCsvString(Photo photo)
        {
            return photo.Id + "," + photo.File.FilePath + "," + photo.IsFavorite.ToString() + "," + photo.AlbumId;
        }

        /// <summary>
        /// 何これ？
        /// </summary>
        /// <param name="photos"></param>
        public void StoreIfNotExists(IEnumerable<Photo> photos)
        {
            throw new NotImplementedException();
        }
    }
}
