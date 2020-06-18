using MediaLibrary.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MediaLibrary.DAL.Tests.MediaRepoTests
{
    [TestClass]
    public class ModifiyMediaTests
    {
        [TestMethod]
        public void ModifyMedia_Successful()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                //ARRANGE
                var media = new MediaTO { Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
                var result = mediaRepo.CreateMedia(media);
                context.SaveChanges();

                //ACT
                result.Name = "Cendrillon Remaster";
                var test = mediaRepo.ModifyMedia(result);
                context.SaveChanges();

                //ASSERT
                Assert.AreEqual("Cendrillon Remaster", test.Name);
            }
        }

        [TestMethod]
        public void ModifyMedia_ProvidingNonExistingMedia_ThrowException()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                var media = new MediaTO { Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
                Assert.ThrowsException<ArgumentException>(() => mediaRepo.ModifyMedia(media));
            }
        }

        [TestMethod]
        public void ModifyMedia_ProvidingNull_ThrowException()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                Assert.ThrowsException<ArgumentNullException>(() => mediaRepo.ModifyMedia(null));
            }
        }
        
        [TestMethod]
        public void ModifyMedia_ProvidingNonExistingId_ThrowException()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                var media = new MediaTO {Id=1450, Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
                Assert.ThrowsException<KeyNotFoundException>(() => mediaRepo.ModifyMedia(media));
            }
        }
    }
}
