using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IAlbumRepository">の実装クラス
    /// </summary>
    class AlbumRepository : IAlbumRepository
    {
        private List<Album> dbAlbums;

        public AlbumRepository()
        {
            this.dbAlbums = new List<Album>();
            dbAlbums.Add(new Album("abc", "test1", "test0説明"));
            dbAlbums.Add(new Album("def", "test2", "test1説明"));
            dbAlbums.Add(new Album("ghi", "test3", "test2説明"));
        }

        public bool Exists(Album entity)
        {
            List<Album> list = (from a in this.dbAlbums where entity.Name == entity.Name select a).ToList();

            if (list.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ExistsBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public IEnumerable<Album> Find(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            return query(this.dbAlbums.AsQueryable()).AsEnumerable();
        }

        public Album Find(Func<IQueryable<Album>, Album> query)
        {
            return query(this.dbAlbums.AsQueryable());
        }

        public Album FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public Album Store(Album entity)
        {
            return entity;
        }
    }
}
