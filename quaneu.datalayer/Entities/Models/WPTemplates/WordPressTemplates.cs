using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace quaneu.datalayer.Models
{
    public class WordPressTemplate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Html)]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int ImageId { get; set; }
        [ForeignKey("ImageId")]
        public quaneu.datalayer.Models.Image.Image Image { get; set; }
    }
}
