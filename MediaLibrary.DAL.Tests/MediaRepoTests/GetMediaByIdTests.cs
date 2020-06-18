using System;
using System.Collections.Generic;
using System.Linq;
using MediaLibrary.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediaLibrary.DAL.Tests.MediaRepoTests
{
    [TestClass]
    public class GetMediaByIdTests
    {
        [TestMethod]
        public void GetMediaById_Successful()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                //ARRANGE
                var media = new MediaTO { Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
                var media2 = new MediaTO { Name = "C# pour les nulls", Type = MediaType.Book, Path = "C:/Book/Code" };
                var media3 = new MediaTO { Name = "The IT Crowd", Type = MediaType.Serie, Path = "C:/Films/Series" };
                mediaRepo.CreateMedia(media);
                mediaRepo.CreateMedia(media2);
                mediaRepo.CreateMedia(media3);
                context.SaveChanges();

                //ACT
                var test = mediaRepo.GetById(2);

                //ASSERT
                Assert.AreEqual("C# pour les nulls", test.Name);
            }
        }

        [TestMethod]
        public void GetMediaById_ProvidingNoId_ThrowException()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                //ARRANGE
                var media = new MediaTO { Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };

                //ASSERT
                Assert.ThrowsException<ArgumentException>(() => mediaRepo.GetById(media.Id));
            }
        }

        [TestMethod]
        public void GetMediaById_ProvidingNonExistingId_ThrowException()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);

                //ASSERT
                Assert.ThrowsException<ArgumentNullException>(() => mediaRepo.GetById(14));
            }
        }
    }
}
