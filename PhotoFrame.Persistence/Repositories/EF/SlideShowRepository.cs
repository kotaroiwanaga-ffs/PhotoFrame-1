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

        public IEnumerable<string> Find(Album album)
        {
            using (TeamBEntities database = new TeamBEntities())
            {
                List<string> photos = new List<string>();

                var phototable = database.ALBUM_TABLE.Find(album.Name).PHOTO_TABLE;

                foreach (var photo in phototable)
                {
                    photos.Add(photo.FILEPATH);
                }
                return photos;
            }    
        }

        public void Store(Album album, Photo photo)
        {
            if (album.Name != null && album.Name != "" && photo.File.FilePath != null && photo.File.FilePath != "")
            {
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

                        transaction.Commit();
                        database.SaveChanges();
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
