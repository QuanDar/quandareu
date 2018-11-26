using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace quaneu.datalayer.Models.Blog
{
    public class BlogPost
    {
        [Key]
        public int BlogId { get; set; }
        [Key]
        public int PostId { get; set; }

        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
