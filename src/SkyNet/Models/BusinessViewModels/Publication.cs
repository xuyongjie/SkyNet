using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.BusinessModels
{
    public class Publication:ModelBase
    {
        public int PublicationId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public Media FrontCoverMedia { get; set; }
        public List<PublicationTag> PublicationTags { get; set; }
        public Media OriginalHtml { get; set; }
        public List<Comment> Comments { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }
    }
}
