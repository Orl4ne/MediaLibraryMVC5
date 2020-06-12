using System;
using MediaLibrary.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediaLibrary.Common.Tests
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void ToTransfertObject_Successfull()
        {
            //ARRANGE
            var media = new MediaEF { Id = 1, Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
            //ACT
            var result = media.ToTransferObject();
            //Assert
            Assert.AreEqual(media.Name, result.Name);
            Assert.AreEqual(media.Id, result.Id);
            Assert.AreEqual(media.Type, result.Type);
            Assert.AreEqual(media.Path, result.Path);
        }
        [TestMethod]
        public void ToEF_Successfull()
        {
            //ARRANGE
            var media = new MediaTO { Id = 1, Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
            //ACT
            var result = media.ToEF();
            //Assert
            Assert.AreEqual(media.Name, result.Name);
            Assert.AreEqual(media.Id, result.Id);
            Assert.AreEqual(media.Type, result.Type);
            Assert.AreEqual(media.Path, result.Path);
        }
    }
}
