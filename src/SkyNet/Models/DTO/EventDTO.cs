using SkyNet.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.DTO
{
    public class EventDTO
    {
        public Event Event { get; set; }
        public ApplicationUser Owner { get; set; }
        public IEnumerable<ApplicationUser> Participants { get; set; }
        public decimal TotalCost { get; set; }
    }
}
