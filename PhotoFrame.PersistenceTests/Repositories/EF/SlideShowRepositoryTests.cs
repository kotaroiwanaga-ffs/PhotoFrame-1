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
        private TransactionScope scope;

        [TestInitialize]
        public void SetUp()
        {
            scope = new TransactionScope();
        }

        [TestCleanup]
        public void TearDown()
        {
            scope.Dispose();
        }

        [TestMethod()]
        public void 保存したスライドショーのフォトリストを取り出せること()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            albumRepository.Store(album1);
            File photofile1 = new File("PhotoTest1.jpg");
            File photofile2 = new File("PhotoTest2.jpg");
            File photofile3 = new File("PhotoTest3.jpg");
            Photo photo1 = new Photo(photofile1, DateTime.Parse("2018/07/17"));
            Photo photo2 = new Photo(photofile2, DateTime.Parse("2018/07/17"));
            Photo photo3 = new Photo(photofile3, DateTime.Parse("2018/07/17"));
            photoRepository.Store(photo1);
            photoRepository.Store(photo2);
            photoRepository.Store(photo3);

            slideshowRepository.Store(album1, photo1);
            slideshowRepository.Store(album1, photo2);
            slideshowRepository.Store(album1, photo3);

            var result = slideshowRepository.Find(album1);
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod()]
        public void アルバム保存しなくてもスライドショーを保存できること()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            File photofile1 = new File("PhotoTest1.jpg");
            File photofile2 = new File("PhotoTest2.jpg");
            File photofile3 = new File("PhotoTest3.jpg");
            Photo photo1 = new Photo(photofile1, DateTime.Parse("2018/07/17"));
            Photo photo2 = new Photo(photofile2, DateTime.Parse("2018/07/17"));
            Photo photo3 = new Photo(photofile3, DateTime.Parse("2018/07/17"));
            photoRepository.Store(photo1);
            photoRepository.Store(photo2);
            photoRepository.Store(photo3);

            slideshowRepository.Store(album1, photo1);
            slideshowRepository.Store(album1, photo2);
            slideshowRepository.Store(album1, photo3);

            var result = slideshowRepository.Find(album1);
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod()]
        public void 写真保存しなくてもスライドショーを保存できること()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            albumRepository.Store(album1);
            File photofile1 = new File("PhotoTest1.jpg");
            File photofile2 = new File("PhotoTest2.jpg");
            File photofile3 = new File("PhotoTest3.jpg");
            Photo photo1 = new Photo(photofile1, DateTime.Parse("2018/07/17"));
            Photo photo2 = new Photo(photofile2, DateTime.Parse("2018/07/17"));
            Photo photo3 = new Photo(photofile3, DateTime.Parse("2018/07/17"));
            photoRepository.Store(photo1);
            photoRepository.Store(photo2);

            slideshowRepository.Store(album1, photo1);
            slideshowRepository.Store(album1, photo2);
            slideshowRepository.Store(album1, photo3);

            var result = slideshowRepository.Find(album1);
            Assert.AreEqual(result.Count(), 3);
        }
    }
}