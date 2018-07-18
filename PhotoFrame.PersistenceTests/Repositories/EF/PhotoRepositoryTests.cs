using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using System.Transactions;

namespace PhotoFrame.Persistence.EF.Tests
{
    [TestClass()]
    public class PhotoRepositoryTests
    {
        PhotoRepository photoRepository = new PhotoRepository();

        [TestMethod()]
        public void PR_01()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            photoRepository.Store(photo1);
        }

        [TestMethod()]
        public void PR_02()
        {
            File photofile1 = new File("");
            Photo photo1 = new Photo(photofile1, new DateTime());
            photoRepository.Store(photo1);
        }

        [TestMethod()]
        public void PR_03()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            photo1.AddKeyword("aaa");
            photoRepository.Store(photo1);
        }

        [TestMethod()]
        public void PR_04()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            photo1.MarkAsFavorite();
            photoRepository.Store(photo1);
        }

        [TestMethod()]
        public void PR_05()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            var result = photoRepository.Exists(photo1);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void PR_06()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            var result = photoRepository.Exists(photo1);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void PR_07()
        {
            var result = photoRepository.Find();
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod()]
        public void PR_08()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            var result = photoRepository.Find(photos => photos.First(
                photo => photo.File.FilePath == "PhotoTest1.jpg"
                ));
            Assert.AreEqual(result, photo1);
        }

        [TestMethod()]
        public void PR_09()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            photo1.AddKeyword("aaa");
            photo1.MarkAsFavorite();
            photoRepository.Store(photo1);

            var result = photoRepository.Find(photos => photos.Where(
                photo => photo.Keywords.Contains("aaa")
                ));
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod()]
        public void PR_10()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            photo1.AddKeyword("aaa");
            photo1.MarkAsFavorite();
            photoRepository.Store(photo1);

            var result = photoRepository.Find(photos => photos.Where(
                photo => photo.IsFavorite == true
                ));
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod()]
        public void PR_11()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile1, new DateTime());
            photo1.AddKeyword("aaa");
            photo1.MarkAsFavorite();
            photoRepository.Store(photo1);

            var result = photoRepository.Find(photos => photos.Where(
                photo => photo.Keywords.Contains("aaa") && photo.IsFavorite == true
                ));
            Assert.AreEqual(result.Count(), 1);
        }
    }
}