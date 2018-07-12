using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<Photo> Execute(string filePath)
        {
            IEnumerable<File> files = photoFileService.FindAllPhotoFilesFromDirectory(filePath);

            //Func<IQueryable<Photo>, Photo> query = ((photo) =>
            //{
                
            //});

            foreach(File file in files)
            {

            }

            List<Photo> photos = new List<Photo>();

            return photos;
        }
    }
}
