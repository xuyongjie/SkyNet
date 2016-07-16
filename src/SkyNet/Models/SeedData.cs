using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SkyNet.Data;
using SkyNet.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.MediaTypes.Any())
                {
                    return;
                }
                context.MediaTypes.AddRange(new MediaType
                {
                    MediaTypeName = MediaTypeName.IMAGE,
                    MediaTypeDescription = "Image file"
                }, new MediaType
                {
                    MediaTypeName = MediaTypeName.AUDIO,
                    MediaTypeDescription = "Audio file"
                }, new MediaType
                {
                    MediaTypeName = MediaTypeName.VIDEO,
                    MediaTypeDescription = "Video file"
                }, new MediaType
                {
                    MediaTypeName = MediaTypeName.HTML,
                    MediaTypeDescription = "Html file"
                });
                context.SaveChanges();
            }
        }
    }
}
