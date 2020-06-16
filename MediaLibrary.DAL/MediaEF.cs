using MediaLibrary.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.DAL
{
    [Table("Medias")]
    public class MediaEF
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public MediaType Type { get; set; }
    }
}
