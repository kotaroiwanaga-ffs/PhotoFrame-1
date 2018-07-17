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
        public void 保存した写真が存在すること()
        {
            File photofile = new File("PhotoTest1.jpg");
            Photo photo1 = new Photo(photofile, DateTime.Parse("2018/01/01"));
            photoRepository.Store(photo1);
            Assert.IsTrue(photoRepository.Exists(photo1));
        }

        [TestMethod()]
        public void 保存しない写真が存在しないこと()
        {
            File photofile = new File("PhotoTest2.jpg");
            Photo photo2 = new Photo(photofile, DateTime.Parse("2018/01/01"));
            Assert.IsFalse(photoRepository.Exists(photo2));
        }

        [TestMethod()]
        public void ファイルパスが空文字の場合保存しないこと()
        {
            File photofile = new File("");
            Photo photo3 = new Photo(photofile, DateTime.Parse("2018/01/01"));
            photoRepository.Store(photo3);
            Assert.IsFalse(photoRepository.Exists(photo3));
        }

        [TestMethod()]
        public void 保存したすべての写真を見つけ出せること()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            File photofile2 = new File("PhotoTest2.jpg");
            File photofile4 = new File("PhotoTest4.jpg");
            Photo photo1 = new Photo(photofile1, DateTime.Parse("2018/01/01"));
            Photo photo2 = new Photo(photofile2, DateTime.Parse("2018/01/01"));
            Photo photo4 = new Photo(photofile4, DateTime.Parse("2018/01/01"));
            photoRepository.Store(photo1);
            photoRepository.Store(photo2);
            photoRepository.Store(photo4);
            var result = photoRepository.Find();
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod()]
        public void アルバム名で写真を見つけ出せること()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            File photofile2 = new File("PhotoTest2.jpg");
            File photofile4 = new File("PhotoTest4.jpg");
            Photo photo1 = new Photo(photofile1, DateTime.Parse("2018/01/01"));
            Photo photo2 = new Photo(photofile2, DateTime.Parse("2018/01/01"));
            Photo photo4 = new Photo(photofile4, DateTime.Parse("2018/01/01"));
            photoRepository.Store(photo1);
            photoRepository.Store(photo2);
            photoRepository.Store(photo4);

            var result = photoRepository.Find(photos =>
                photos.First(photo => photo.File.FilePath == "PhotoTest1.jpg")
            );

            Assert.AreEqual(result, photo1);
        }

        [TestMethod()]
        public void キーワードでフォトリストを見つけ出せること()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            File photofile2 = new File("PhotoTest2.jpg");
            File photofile4 = new File("PhotoTest4.jpg");

            string[] keywords = { "aaa" };

            Photo photo1 = new Photo(photofile1, DateTime.Parse("2018/01/01"), keywords);
            Photo photo2 = new Photo(photofile2, DateTime.Parse("2018/01/01"), keywords);
            Photo photo4 = new Photo(photofile4, DateTime.Parse("2018/01/01"));

            photoRepository.Store(photo1);
            photoRepository.Store(photo2);
            photoRepository.Store(photo4);

            var result = photoRepository.Find(photos => photos.Where(photo => photo.Keywords.Contains("aaa")));
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod()]
        public void お気に入りでフォトリストを見つけ出せること()
        {
            File photofile1 = new File("PhotoTest1.jpg");
            File photofile2 = new File("PhotoTest2.jpg");
            File photofile4 = new File("PhotoTest4.jpg");

            string[] keywords = { "aaa" };

            Photo photo1 = new Photo(photofile1, DateTime.Parse("2018/01/01"));
            Photo photo2 = new Photo(photofile2, DateTime.Parse("2018/01/01"));
            Photo photo4 = new Photo(photofile4, DateTime.Parse("2018/01/01"));

            photo1.MarkAsFavorite();
            photo2.MarkAsFavorite();

            photoRepository.Store(photo1);
            photoRepository.Store(photo2);
            photoRepository.Store(photo4);

            var result = photoRepository.Find(photos => photos.Where(photo => photo.IsFavorite == true));
            Assert.AreEqual(result.Count(), 2);
        }

    }
}