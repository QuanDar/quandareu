using quaneu.datalayer.Models.Blog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace quaneu.datalayer.Models.Work
{
    public class Work
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string URL { get; set; }
        public int ImageId { get; set; }
        [ForeignKey("ImageId")]
        public quaneu.datalayer.Models.Image.Image Image { get; set; }
        public Post Post { get; set; }
    }
}
