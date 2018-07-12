using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Persistence.Repositories.EF;
using System.Data.Entity;

namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IAlbumRepository">の実装クラス
    /// </summary>
    class AlbumRepository : IAlbumRepository
    {
        public IEnumerable<Album> Find()
        {
            using (TeamBEntities database = new TeamBEntities())
            {
                List<Album> allAlbum = new List<Album>();
                DbSet<ALBUM_TABLE> albumtable = database.ALBUM_TABLE;
                foreach(var data in albumtable)
                {
                    Album album = Album.Create(data.NAME);
                    allAlbum.Add(album);
                }
                return allAlbum;
            }
        }

        public Album Store(Album album)
        {
            using (TeamBEntities database = new TeamBEntities())
            {
                DbSet<ALBUM_TABLE> albumtable = database.ALBUM_TABLE;
                var saveAlbum = new ALBUM_TABLE
                {
                    NAME = album.Name
                };
                albumtable.Add(saveAlbum);
            }
            return album;
        }

        public bool Exists(Album album)
        {
            using (TeamBEntities database = new TeamBEntities())
            {
                DbSet<ALBUM_TABLE> albumtable = database.ALBUM_TABLE;
                foreach(var data in albumtable)
                {
                    if (data.NAME == album.Name) return true;
                }
                return false;
            }
            
        }

        public bool ExistsBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public IEnumerable<Album> Find(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public Album Find(Func<IQueryable<Album>, Album> query)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }


        public Album FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

    }
}
