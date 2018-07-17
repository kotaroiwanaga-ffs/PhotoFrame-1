using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Persistence.Repositories.EF
{
    public class SlidShowRepository
    {
        List<string[]> dbSlide;

        public SlidShowRepository()
        {
            this.dbSlide = new List<string[]>();

            dbSlide.Add(new string[] { "test1", @"C:\研修用\Album1\Chrysanthemum.jpg" });
        }

        public IEnumerable<string> FindSlideShow(Album album)
        {
            List<string> list = new List<string>();
            foreach (var p in this.dbSlide)
            {
                if (p[0] == album.Name)
                {
                    list.Add(p[1]);
                }
            }

            return list;
        }

        public Album StoreSlideShow(Album album, IEnumerable<Photo> photos)
        {
            return album;
        }
    }
}
