using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.BusinessModels
{
    public class MediaType
    {
        [Key]
        public string MediaTypeName { get; set; }
        public string MediaTypeDescription { get; set; }
    }
}
