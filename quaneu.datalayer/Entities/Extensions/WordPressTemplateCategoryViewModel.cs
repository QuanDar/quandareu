using quaneu.datalayer.Models;
using quaneu.datalayer.Models.Image;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace quaneu.datalayer.Entities.Extensions
{
    public class WordPressTemplateCategoryViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Html)]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public IEnumerable<WordPressCategory> Categories { get; set; }
        public int ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image Image { get; set; }
    }
}
