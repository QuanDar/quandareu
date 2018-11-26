using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace quaneu.datalayer.Entities.Extensions
{
    public class BlogViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
