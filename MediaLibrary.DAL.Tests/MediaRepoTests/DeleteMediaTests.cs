using System;
using System.Collections.Generic;
using System.Linq;
using MediaLibrary.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediaLibrary.DAL.Tests.MediaRepoTests
{
    [TestClass]
    public class DeleteMediaTests
    {
        [TestMethod]
        public void DeleteMedia_Successful()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                //ARRANGE
                var media = new MediaTO { Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
                var media2 = new MediaTO { Name = "C# pour les nulls", Type = MediaType.Book, Path = "C:/Book/Code" };
                var media3 = new MediaTO { Name = "The IT Crowd", Type = MediaType.Serie, Path = "C:/Films/Series" };
                var result = mediaRepo.CreateMedia(media);
                var result2 = mediaRepo.CreateMedia(media2);
                var result3 = mediaRepo.CreateMedia(media3);
                context.SaveChanges();

                //ACT
                var test = mediaRepo.DeleteMedia(result);
                context.SaveChanges();

                //ASSERT
                Assert.AreEqual(2, context.Medias.Count());
            }
        }

        [TestMethod]
        public void DeleteMedia_ProvidingNull_ThrowException()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                Assert.ThrowsException<KeyNotFoundException>(() => mediaRepo.DeleteMedia(null));
            }
        }

        [TestMethod]
        public void DeleteMedia_ProvidingNonExistingMedia_ThrowException()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                var media = new MediaTO { Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
                Assert.ThrowsException<ArgumentException>(() => mediaRepo.DeleteMedia(media));
            }
        }
    }
}
