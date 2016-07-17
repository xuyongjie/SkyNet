using System;
using System.ComponentModel.DataAnnotations;

namespace SkyNet.Models.BusinessModels
{
    public class Comment:IModelBase,IBaseId
    {
        public int Id { get; set; }
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
