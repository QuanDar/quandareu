using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace quaneu.datalayer.Entities.Extensions
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
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
