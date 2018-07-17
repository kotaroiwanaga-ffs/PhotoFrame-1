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
    public class AlbumRepositoryTests
    {
        AlbumRepository albumRepository = new AlbumRepository();
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
        public void 保存したアルバムが存在すること()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            albumRepository.Store(album1);
            var result = albumRepository.Exists(album1);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void 保存しないアルバムが存在しないこと()
        {
            Album album2 = new Album("", "AlbumTest2", "");
            var result = albumRepository.Exists(album2);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void アルバム名が空文字の場合保存しないこと()
        {
            Album album3 = new Album("", "", "");
            albumRepository.Store(album3);
            var result = albumRepository.Exists(album3);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void 保存したすべてのアルバムを見つけ出せること()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            Album album2 = new Album("", "AlbumTest2", "");
            Album album4 = new Album("", "AlbumTest4", "");
            albumRepository.Store(album1);
            albumRepository.Store(album2);
            albumRepository.Store(album4);
            var result = albumRepository.Find();
            Assert.AreEqual(result.Count(), 3);
        }
    }
}