using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Persistence.EF.Tests
{
    [TestClass()]
    public class AlbumRepositoryTests
    {
        AlbumRepository albumRepository = new AlbumRepository();

        [TestMethod()]
        public void AP_01()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            albumRepository.Store(album1);
        }

        [TestMethod()]
        public void AP_02()
        {
            Album album1 = new Album("", "", "");
            albumRepository.Store(album1);
        }

        [TestMethod()]
        public void AP_03()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            var result = albumRepository.Exists(album1);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void AP_04()
        {
            Album album1 = new Album("", "AlbumTest1", "");
            var result = albumRepository.Exists(album1);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AP_05()
        {
            var result = albumRepository.Find();
            Assert.AreEqual(result.Count(), 3);
        }
    }
}