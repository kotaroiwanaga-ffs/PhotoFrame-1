using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Persistence.Repositories.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using System.Transactions;
using PhotoFrame.Persistence.EF;

namespace PhotoFrame.Persistence.Repositories.EF.Tests
{
    [TestClass()]
    public class SlideShowRepositoryTests
    {
        AlbumRepository albumRepository = new AlbumRepository();
        PhotoRepository photoRepository = new PhotoRepository();
        SlideShowRepository slideshowRepository = new SlideShowRepository();

        [TestMethod()]
        public void SR_01()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            albumRepository.Store(album1);
            photoRepository.Store(photo1);
            slideshowRepository.Store(album1, photo1);
        }

        [TestMethod()]
        public void SR_02()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            photoRepository.Store(photo1);
            slideshowRepository.Store(album1, photo1);
        }

        [TestMethod()]
        public void SR_03()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            albumRepository.Store(album1);
            slideshowRepository.Store(album1, photo1);
        }

        [TestMethod()]
        public void SR_04()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            slideshowRepository.Store(album1, photo1);
        }

        [TestMethod()]
        public void SR_05()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            var result = slideshowRepository.Find(album1);
            Assert.AreEqual(result.Count(), 0);
        }

        [TestMethod()]
        public void SR_06()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            var result = slideshowRepository.Find(album1);
            Assert.AreEqual(result.Count(), 3);
        }
    }
}