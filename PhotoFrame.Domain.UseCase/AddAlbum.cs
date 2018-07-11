using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class AddAlbum
    {
        public bool Execute(string albumName, IEnumerable<Photo> photos)
        {


            return true;
        }
    }
}
