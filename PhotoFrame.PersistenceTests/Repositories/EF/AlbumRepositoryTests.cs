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
        public void 保存されたすべてのアルバムを読みだせること()
        {
            Album album1 = new Album("", "saveAlbumTest1", "");
            Album album2 = new Album("", "saveAlbumTest2", "");
            Album album3 = new Album("", "saveAlbumTest3", "");
            albumRepository.Store(album1);
            albumRepository.Store(album2);
            albumRepository.Store(album3);
            var result = albumRepository.Find();
            Assert.AreEqual(3,result.Count());
        }

        [TestMethod()]
        public void アルバムを保存できること()
        {
            Album album = new Album("", "saveAlbumTest", "");
            var result = albumRepository.Store(album);
            Assert.AreEqual(result, album);
        }

        [TestMethod()]
        public void 存在するアルバムを見つけ出せること()
        {
            Album album = new Album("", "ExistsTest", "");
            albumRepository.Store(album);
            var result = albumRepository.Exists(album);
            Assert.AreEqual(result, true);
        }
    }
}