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
            using (PhotoFrameDBEntities entity = new PhotoFrameDBEntities())
            {
                var allTable_Albums = from album in entity.Table_Album select album;

                return query(ToAlbum(allTable_Albums));
            }
        }

        public Album Find(Func<IQueryable<Album>, Album> query)
        {
            // TODO: DBプログラミング講座で実装
            using (PhotoFrameDBEntities entity = new PhotoFrameDBEntities())
            {
                var allTable_Albums = from album in entity.Table_Album select album;

                return query(ToAlbum(allTable_Albums));
            }
        }

        public Album FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public Album Store(Album entity)
        {
            // TODO: DBプログラミング講座で実装
            //Table_Album  = Find((IQueryable<products> allProduct) => { return (from p in allProduct where p.id == product.id select p).FirstOrDefault(); });
            //bool hit = SELECT CASE WHEN(10 > 0) THEN 'true' ELSE 'false' END AS MY_BOOLEAN_COLUMN FROM DUAL
            Album hitAlbum = Find((IQueryable<Album> allAlbums) => { return (from album in allAlbums where album.Id == entity.Id select album).FirstOrDefault(); });


            using (PhotoFrameDBEntities dbentity = new PhotoFrameDBEntities())
            {
                using (var transaction = dbentity.Database.BeginTransaction())
                {
                    Table_Album hit_table_Album = (from album in dbentity.Table_Album where album.Id == Guid.Parse(entity.Id) select album).FirstOrDefault();

                    try
                    {
                        // Update
                        if (hitAlbum != null)
                        {
                            hit_table_Album.Name = entity.Name;
                            hit_table_Album.Descript = entity.Description;
                        }
                        // Insert
                        else
                        {
                            Table_Album newTable_Album = ToDataBase(entity);
                            dbentity.Table_Album.Add(newTable_Album);
                        }

                        transaction.Commit();

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

        public Album ToAlbum(Table_Album table_Album)
        {
            return new Album(table_Album.Id.ToString(), table_Album.Name, table_Album.Descript);
        }

        public IQueryable<Album> ToAlbum(IQueryable<Table_Album> table_Albums)
        {
            List<Album> albums = new List<Album>();

            foreach(Table_Album table_Album in table_Albums)
            {
                albums.Add(ToAlbum(table_Album));
            }

            return albums.AsQueryable();
        }

        public Table_Album ToDataBase(Album album)
        {
            Table_Album table_album = new Table_Album();

            table_album.Id = Guid.Parse(album.Id);
            table_album.Name = album.Name;
            table_album.Descript = album.Description;

            return table_album;
        }

        public IEnumerable<Table_Album> ToDataBase(IQueryable<Album> albums)
        {
            List<Table_Album> table_Albums = new List<Table_Album>();

            foreach(Album album in albums)
            {
                table_Albums.Add(ToDataBase(album));
            }

            return table_Albums;
        }
    }
}
