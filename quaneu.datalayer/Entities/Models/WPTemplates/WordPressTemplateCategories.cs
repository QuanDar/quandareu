using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace quaneu.datalayer.Models
{
    public class WordPressTemplateCategory
    {
        [Key]
        public int WordPressCategoryId { get; set; }
        [ForeignKey("WordPressCategoryId")]
        public WordPressCategory WordPressCategory { get; set; }
        [Key]
        public int WordPressTemplateId { get; set; }
        [ForeignKey("WordPressTemplateId")]
        public WordPressTemplate WordPressTemplate { get; set; }

        
    }
}
