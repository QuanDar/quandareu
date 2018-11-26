using quaneu.datalayer.Models.Blog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace quaneu.datalayer.Entities.Extensions
{
    public class PostBlogViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Post Title")]
        [Required(ErrorMessage = "Post Title is required")]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 3 characters required")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Invalid Title Lenght")]
        public string Title { get; set; }

        [StringLength(50)]
        [DataType(DataType.Html)]
        [Display(Name = "Short Content")]
        [Required(ErrorMessage = "Short Content is required")]
        public string Description { get; set; }

        // kies of een post url of een Controller + Action
        [DataType(DataType.Url)]
        public string Url { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        [DataType(DataType.Html)]
        [MaxLength(Int32.MaxValue, ErrorMessage = "More than max value")]
        [Display(Name = "Full Content")]
        [Required(ErrorMessage = "Full Content is required")]
        public string Content { get; set; }

        [StringLength(255)]
        public string MetaKeywords { get; set; }

        [StringLength(500)]
        public string MetaDescription { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }

        public bool IsCommented { get; set; }

        public bool IsShared { get; set; }
        public bool IsPrivate { get; set; }
        public int NumberOfViews { get; set; }

        [ForeignKey("ImageId")]
        public quaneu.datalayer.Models.Image.Image Image { get; set; }
        public int ImageId { get; set; }

        public int NumberOfLikes { get; set; }

        public int NumberOfComments { get; set; }

        public int NumberOfDislikes { get; set; }


        public virtual List<Comment> Comments { get; set; }

        public virtual List<BlogViewModel> Categories { get; set; }

        //public ApplicationUser UserId { get; set; }
    }
}
