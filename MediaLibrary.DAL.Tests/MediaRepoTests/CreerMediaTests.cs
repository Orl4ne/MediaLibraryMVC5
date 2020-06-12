using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;

namespace MediaLibrary.DAL.Tests.MediaRepoTests
{
    [TestClass]
    public class CreerMediaTests
    {
        [TestMethod]
        public void CreerMedia_Successful()
        {
            using (var context = new MediaLibraryContext(Effort.DbConnectionFactory.CreateTransient())) 
            { 

            }
        }
    }
}
