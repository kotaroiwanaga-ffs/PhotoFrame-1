using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Persistence.EF;

namespace PhotoFrame.Persistence.Repositories.EF
{
    public class SlideShowRepository
    {
        private AlbumRepository albumRepository = new AlbumRepository();
        private PhotoRepository photoRepository = new PhotoRepository();

        /// <summary>
        /// DBに該当アルバムに所属するすべての写真を見つけて返す
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        public IEnumerable<string> Find(Album album)
        {
            using (TeamBEntities database = new TeamBEntities())
            {
                List<string> photos = new List<string>();

                if (albumRepository.Exists(album))
                {
                    var phototable = database.ALBUM_TABLE.Find(album.Name).PHOTO_TABLE;

                    foreach (var photo in phototable)
                    {
                        photos.Add(photo.FILEPATH);
                    }
                }
                return photos;
            }    
        }

        /// <summary>
        /// 写真をアルバムに所属するように処理する
        /// </summary>
        /// <param name="album"></param>
        /// <param name="photo"></param>
        public void Store(Album album, Photo photo)
        {
            if (album.Name != null && album.Name != "" && photo.File.FilePath != null && photo.File.FilePath != "")
            {
                //アルバム或いは写真が存在しない場合、新規保存する
                if (!albumRepository.Exists(album)) albumRepository.Store(album);
                if (!photoRepository.Exists(photo)) photoRepository.Store(photo);

                using (TeamBEntities database = new TeamBEntities())
                using (var transaction = database.Database.BeginTransaction())
                {
                    try
                    {
                        var albumtable = database.ALBUM_TABLE.Find(album.Name);
                        var phototable = database.PHOTO_TABLE.Find(photo.File.FilePath);
                        albumtable.PHOTO_TABLE.Add(phototable);

                        database.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
            else throw new Exception (message: "アルバム名or写真ファイルパスは空文字もしくはnullです");
        }
    }
}
