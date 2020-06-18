using MediaLibrary.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [StringLength(80, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public MediaType Type { get; set; }
    }
}
