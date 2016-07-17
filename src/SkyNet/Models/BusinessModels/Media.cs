using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.BusinessModels
{
    public class Media:IModelBase,IBaseId
    {
        public int Id { get; set; }
        public string MediaUrl { get; set; }
        public string MediaDescription { get; set; }
        [Required]
        public string MediaTypeName { get; set; }
        public MediaType MediaType { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }
    }
}
