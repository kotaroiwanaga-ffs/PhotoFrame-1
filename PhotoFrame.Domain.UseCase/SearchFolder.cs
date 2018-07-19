using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;


namespace PhotoFrame.Domain.UseCase
{
    public class SearchFolder
    {
        private readonly RepositoryMaster repositoryMaster;
        private readonly IPhotoFileService photoFileService;

        public SearchFolder(RepositoryMaster repositoryMaster, IPhotoFileService photoFileService)
        {
            this.repositoryMaster = repositoryMaster;
            this.photoFileService = photoFileService;
        }

        public IEnumerable<Photo> Execute(string folderPath)
        {
            List<Photo> photos = new List<Photo>();
            IEnumerable<File> files = photoFileService.FindAllPhotoFilesFromDirectory(folderPath);


            foreach(File file in files)
            {
                Func<IQueryable<Photo>, Photo> query = ((folderPhotos) =>
                {
                    return folderPhotos
                        .Where(p => p.File.FilePath == file.FilePath)
                        .FirstOrDefault();
                });

                Photo hitPhoto = repositoryMaster.FindPhoto(query);

                if(hitPhoto != null)
                {
                    photos.Add(hitPhoto);
                }
                else
                {
                    photos.Add(new Photo(file, GetFilmingDate(file.FilePath)));
                }
            }

            this.repositoryMaster.SetAllPhotos(photos);

            return photos;
        }

        private DateTime GetFilmingDate(string filePath)
        {
            System.IO.FileStream stream = System.IO.File.OpenRead(filePath);
            Image image = Image.FromStream(stream, false, false);
            DateTime defaultDate = new DateTime();

            foreach(PropertyItem item in image.PropertyItems)
            {
                if(item.Id == 0x9003 && item.Type == 2)
                {
                    string val = System.Text.Encoding.ASCII.GetString(item.Value);
                    val = val.Trim(new char[] { '\0' });
                    defaultDate = DateTime.ParseExact(val, "yyyy:MM:dd HH:mm:ss", null);
                }
            }

            if(defaultDate != null)
            {
                return defaultDate;
            }
            else
            {
                return new DateTime();
            }
        }

    }
}
