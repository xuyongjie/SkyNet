using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.BusinessModels
{
    public class Tag : IModelBase
    {
        [Key]
        public string TagName { get; set; }
        public List<PublicationTag> PublicationTags { get; set; }
        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }
    }
}
