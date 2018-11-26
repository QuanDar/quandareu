using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace quaneu.datalayer.Models.Image
{
    public class ImageCategory
    {
        [Key]
        public int ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image Image { get; set; }

        [Key]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
