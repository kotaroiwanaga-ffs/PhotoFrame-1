using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using PhotoFrame.Persistence.Repositories.EF;

namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IAlbumRepository">の実装クラス
    /// </summary>
    class AlbumRepository : IAlbumRepository
    {
        public bool Exists(Album entity)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public bool ExistsBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public IEnumerable<Album> Find(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            // TODO: DBプログラミング講座で実装
            return query(FindAll());
            
        }

        public Album Find(Func<IQueryable<Album>, Album> query)
        {
            // TODO: DBプログラミング講座で実装
            return query(FindAll());
        }

        public Album FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            return Find((IQueryable<Album> allAlbums) => { return (from album in allAlbums where album.Id == id select album).FirstOrDefault(); });
        }

        public Album Store(Album entity)
        {
            // TODO: DBプログラミング講座で実装
            using (PhotoFrameDBEntities dbentity = new PhotoFrameDBEntities())
            {
                using (var transaction = dbentity.Database.BeginTransaction())
                {
                    Guid guid = Guid.Parse(entity.Id);

                    Table_Album hit_table_Album = (from t_album in dbentity.Table_Album where t_album.Id == guid select t_album).FirstOrDefault();

                    try
                    {
                        // Update
                        if (hit_table_Album != null)
                        {
                            hit_table_Album.Name = entity.Name;
                            hit_table_Album.Descript = entity.Description;
                        }
                        // Insert
                        else
                        {
                            Table_Album newTable_Album = toDatabase(entity);
                            dbentity.Table_Album.Add(newTable_Album);
                        }

                        transaction.Commit();
                        dbentity.SaveChanges();

                        return entity;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

            }
        }

        private IQueryable<Album> FindAll()
        {
            using (PhotoFrameDBEntities dbentity = new PhotoFrameDBEntities())
            {
                IQueryable<Table_Album> allTable_Albums = (from t_album in dbentity.Table_Album select t_album);

                return (ToAlbum(allTable_Albums));
            }
        }

        private Album ToAlbum(Table_Album table_Album)
        {
            if(table_Album != null)
            {
                return new Album(table_Album.Id.ToString(), table_Album.Name, table_Album.Descript);
            }
            else
            {
                return null;
            }
        }

        private IQueryable<Album> ToAlbum(IQueryable<Table_Album> table_Albums)
        {
            List<Album> albums = new List<Album>();

            foreach(Table_Album table_Album in table_Albums)
            {
                albums.Add(ToAlbum(table_Album));
            }

            return albums.AsQueryable();
        }

        private Table_Album toDatabase(Album album)
        {
            if(album != null)
            {
                Table_Album table_Album = new Table_Album();

                table_Album.Id = Guid.Parse(album.Id);
                table_Album.Name = album.Name;
                table_Album.Descript = album.Description;

                return table_Album;
            }
            else
            {
                return null;
            }
        }

        private IQueryable<Table_Album> toDatabase(IQueryable<Album> albums)
        {
            List<Table_Album> table_Albums = new List<Table_Album>();

            foreach(Album album in albums)
            {
                table_Albums.Add(toDatabase(album));
            }

            return table_Albums.AsQueryable();
        }
    }
}
