using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.BusinessModels
{
    public class PublicationTag:IBaseId
    {
        public int Id { get; set; }
        [Required]
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        [Required]
        public string TagName { get; set; }
        public Tag Tag { get; set; }
    }
}
