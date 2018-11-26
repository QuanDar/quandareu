using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace quaneu.datalayer.Models
{
    public class WordPressCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
