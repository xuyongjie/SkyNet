using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.BusinessModels
{
    interface ModelBase
    {
        DateTime CreateTime { get; set; }
        DateTime ModifyTime { get; set; }
    }
}
