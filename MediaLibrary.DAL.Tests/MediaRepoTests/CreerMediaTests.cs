using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using MediaLibrary.Common;

namespace MediaLibrary.DAL.Tests.MediaRepoTests
{
    [TestClass]
    public class CreerMediaTests
    {
        [TestMethod]
        public void CreerMedia_Successful()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection)) 
            {
                IRepo mediaRepo = new MediaRepo(context);
                //ACT
                var media = new MediaTO { Name = "Cendrillon",Type=MediaType.Film, Path="C:/Films/Animation" };
                var result = mediaRepo.CreerMedia(media);
                context.SaveChanges();

                //ASSERT
                Assert.IsNotNull(result);
                Assert.AreEqual("Cendrillon", result.Name);
                Assert.AreEqual(1, result.Id);
            }
        }
    }
}
