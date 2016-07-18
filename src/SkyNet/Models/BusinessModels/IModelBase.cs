using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models.BusinessModels
{
    public interface IModelBase
    {
        DateTime CreateTime { get; set; }
        DateTime ModifyTime { get; set; }
    }
}
