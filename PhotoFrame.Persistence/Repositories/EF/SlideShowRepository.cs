using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Persistence.Repositories.EF;

namespace PhotoFrame.Persistence.Repositories.EF
{
    class SlideShowRepository
    {
        public IEnumerable<string> Find(Album album)
        {
            using (TeamBEntities database = new TeamBEntities())
            {
                
            }
            throw new NotImplementedException();
        }

        public void Store(Album album, Photo photo)
        {
            using (TeamBEntities database = new TeamBEntities())
            using (var transaction = database.Database.BeginTransaction())
            {
                try
                {
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
