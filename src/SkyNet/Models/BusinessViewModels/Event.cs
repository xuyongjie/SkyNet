using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.BusinessModels
{
    public class Event : ModelBase
    {
        public int EventId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public Media FrontCoverMedia { get; set; }
        public List<EventNode> EventNodes { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }
    }
}
