using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhotoFrame.Persistence.Csv
{
    /// <summary>
    /// <see cref="IAlbumRepository">の実装クラス
    /// </summary>
    class AlbumRepository : IAlbumRepository
    {
        /// <summary>
        /// 永続化ストアとして利用するCSVファイルパス
        /// </summary>
        private string CsvFilePath { get; }

        public AlbumRepository(string databaseName)
        {
            this.CsvFilePath = $"{databaseName}_Album.csv"; // $"{...}" : 文字列展開
        }

        /// <summary>
        /// ??? ExistsByとの違いも使いどころも謎(未使用)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Exists(Album entity)
        {
            return FindBy(entity.Id) != null;
        }

        /// <summary>
        /// 指定したIDのアルバムがあるかどうか(未使用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistsBy(string id)
        {
            return FindBy(id) != null;
        }

        /// <summary>
        /// 検索条件(query)に該当するすべてのアルバムを取得
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<Album> Find(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            IQueryable<Album> allAlbums = FindAll();

            if (allAlbums != null)
            {
                return query(allAlbums);
            }
            // csvファイルがなかった場合
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 検索条件(query)に該当するアルバムを一つ分取得
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Album Find(Func<IQueryable<Album>, Album> query)
        {
            IQueryable<Album> allAlbums = FindAll();

            if(allAlbums != null)
            {
                return query(allAlbums);
            }
            // csvファイルがなかった場合
            else
            {
                return null;
            }
            
        }

        /// <summary>
        /// IDの合致するアルバムの取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Album FindBy(string id)
        {
            IQueryable<Album> allAlbums = FindAll();

            // csvファイルがあった場合
            if (allAlbums != null)
            {
                for (int i = 0; i < allAlbums.Count(); i++)
                {
                    if (allAlbums.ElementAt(i).Id == id)
                    {
                        return allAlbums.ElementAt(i);
                    }
                }

                // なかったよ
                return null;
            }
            // csvファイルがなかった場合
            else
            {
                return null;
            }

        }

        /// <summary>
        /// アルバムの更新・新規追加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Album Store(Album entity)
        {
            IQueryable<Album> otherAlbums = FindAll(entity);

            using (StreamWriter sw = new StreamWriter(this.CsvFilePath, true))
            {
                // ファイルあった場合
                if (otherAlbums != null)
                {
                    // 既存アルバムデータの書き込み
                    foreach(Album album in otherAlbums)
                    {
                        sw.WriteLine(ToCsvString(album));
                    }
                }

                // 新規アルバムデータ書き込み
                sw.WriteLine(ToCsvString(entity));
            }

            return entity;
        }

        /// <summary>
        /// Csvファイル内のすべてのアルバムの取得
        /// (引数にアルバムを渡した場合はそのアルバムと同じIDのアルバムをリストから除く)
        /// </summary>
        /// <returns></returns>
        IQueryable<Album> FindAll(Album album = null)
        {
            List<Album> albums = new List<Album>();

            if (System.IO.File.Exists(this.CsvFilePath))
            {

                using (StreamReader sr = new StreamReader(CsvFilePath, Encoding.UTF8))
                {
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        string[] albumData = line.Split(',');
                        if (album == null || albumData[0] != album.Id)
                        {
                            albums.Add(new Album(albumData[0], albumData[1], albumData[2]));
                        }
                    }
                }

                return albums.AsQueryable();
            }
            //csvファイルがなかった場合
            else
            {
                return null;
            }
        }

        /// <summary>
        /// AlbumをCsvファイル保存用のString型に変換
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        string ToCsvString(Album album)
        {
            return album.Id + "," + album.Name + "," + album.Description;
        }

    }
}
