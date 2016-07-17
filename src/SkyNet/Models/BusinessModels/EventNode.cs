using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.BusinessModels
{
    public class EventNode:IModelBase,IBaseId
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Comment { get; set; }
        public List<Media> Medias { get; set; }
        public bool HasCost { get; set; }
        public decimal Cost { get; set; }
        public bool IsPublic { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }
    }
}
