﻿using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Persistence.Repositories.EF;

namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IAlbumRepository">の実装クラス
    /// </summary>
    public class AlbumRepository : IAlbumRepository
    {
        //DBから保存したすべてのアルバムをAlbum型に変更して返す
        public IEnumerable<Album> Find()
        {
            using (TeamBEntities database = new TeamBEntities())
            {
                List<Album> allAlbum = new List<Album>();
                foreach(var data in database.ALBUM_TABLE)
                {
                    Album album = Album.Create(data.NAME);
                    allAlbum.Add(album);
                }
                return allAlbum;
            }
        }

        /// <summary>
        /// アルバムを新規保存
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        public Album Store(Album album)
        {
            if (!Exists(album) && album.Name != null && album.Name != "")
            {
                using (TeamBEntities database = new TeamBEntities())
                using (var transaction = database.Database.BeginTransaction())
                {
                    try
                    {
                        var saveAlbum = new ALBUM_TABLE
                        {
                            NAME = album.Name
                        };

                        database.ALBUM_TABLE.Add(saveAlbum);

                        database.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
            return album;
        }

        /// <summary>
        /// アルバムがDBに存在しているかどうかを確認
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        public bool Exists(Album album)
        {
            using (TeamBEntities database = new TeamBEntities())
            {
                if (album.Name != null && album.Name != "")
                {
                    foreach (var data in database.ALBUM_TABLE)
                    {
                        if (data.NAME == album.Name) return true;
                    }
                    return false;
                }
                else return false;
            }
        }

        public bool ExistsBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public IEnumerable<Album> Find(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            return query(Find().AsQueryable());
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
