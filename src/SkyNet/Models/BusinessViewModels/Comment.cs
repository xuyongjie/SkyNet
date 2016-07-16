using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.BusinessModels
{
    public class Comment:ModelBase
    {
        public int CommentId { get; set; }
        [Required]
        public string FromUserId { get; set; }
        public ApplicationUser FromUser { get; set; }
        public string ToUserId { get; set; }
        public ApplicationUser ToUser { get; set; }
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
    }
}
