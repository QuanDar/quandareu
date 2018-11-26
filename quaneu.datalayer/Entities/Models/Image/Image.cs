using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace quaneu.datalayer.Models.Image
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        // Also used for alt in HTML
        public string Name { get; set; }
        [DataType(DataType.ImageUrl)]
        [Required]
        public string Url { get; set; }
        public string ContentType { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
