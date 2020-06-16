using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.DAL
{
    public class MediaLibraryContext : DbContext
    {
        public MediaLibraryContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediaLibraryDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }
        public MediaLibraryContext(DbConnection connection) : base(connection, false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MediaEF> Medias { get; set; }
            
    }
}
