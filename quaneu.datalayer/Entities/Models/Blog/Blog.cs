using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace quaneu.datalayer.Models.Blog
{
    // this is the category for the posts
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }

        // for future when there are multiple blogs
        //[StringLength(50)]
        //[Required(ErrorMessage = "Title is required")]
        //public string Title { get; set; }

        //[StringLength(50)]
        //[Required(ErrorMessage = "Discription is required")]
        //public string Discription { get; set; }
    }
}
