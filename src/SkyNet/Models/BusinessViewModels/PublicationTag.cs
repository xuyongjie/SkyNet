using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.BusinessModels
{
    public class PublicationTag
    {
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        public string TagName { get; set; }
        public Tag Tag { get; set; }
    }
}
