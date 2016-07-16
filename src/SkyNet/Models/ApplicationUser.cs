using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SkyNet.Models.BusinessModels;

namespace SkyNet.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, ModelBase
    {
        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarUrl { get; set; }
        /// <summary>
        /// 座右铭
        /// </summary>
        public string Motto { get; set; }


        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }
    }
}
