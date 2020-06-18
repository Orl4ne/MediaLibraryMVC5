using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Common
{
    public class MediaTO
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
