using quaneu.datalayer.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace quaneu.datalayer.Models.Blog
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
#warning hoe moet je linken naar de user table. Als ik dit zo laat staan komt er een nieuwe table in de DataBase
#warning string UserName moet QuanUser QuanUser worden. 
        //private int QuanUserId { get; set; }
        //public QuanUser QuanUser { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AddDate { get; set; }
        [Required]

        public string CommentText { get; set; }

        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        [Required]
        public int ParentCommentId { get; set; }
    }
}
