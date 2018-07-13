using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Persistence.Repositories.EF;

namespace PhotoFrame.Persistence.Repositories.EF
{
    public class SlideShowRepository
    {
        public IEnumerable<string> Find(Album album)
        {
            using (TeamBEntities database = new TeamBEntities())
            {
                var phototable = database.ALBUM_TABLE.Find(album.Name).PHOTO_TABLE;

                List<string> photos = new List<string>();
                foreach(var photo in phototable)
                {
                    photos.Add(photo.FILEPATH);
                }
                return photos;
            }          
        }

        public void Store(Album album, Photo photo)
        {
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
    }
}
