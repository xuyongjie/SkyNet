using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkyNet.Models;
using SkyNet.Models.BusinessModels;

namespace SkyNet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventNode> EventNodes { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<Publication> Pulications { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PublicationTag> PublicationTags { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<PublicationTag>().HasKey(pt => new
            {
                pt.PublicationId,
                pt.TagName
            });
        }
        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries().Where(e => e.Entity is IModelBase && (e.State == EntityState.Added || e.State == EntityState.Modified)).Select(e => e.Entity as IModelBase))
            {
                history.ModifyTime = DateTime.Now;
                if (history.CreateTime == DateTime.MinValue)
                {
                    history.CreateTime = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var history in this.ChangeTracker.Entries().Where(e => e.Entity is IModelBase && (e.State == EntityState.Added || e.State == EntityState.Modified)).Select(e => e.Entity as IModelBase))
            {
                history.ModifyTime = DateTime.Now;
                if (history.CreateTime == DateTime.MinValue)
                {
                    history.CreateTime = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            foreach (var history in this.ChangeTracker.Entries().Where(e => e.Entity is IModelBase && (e.State == EntityState.Added || e.State == EntityState.Modified)).Select(e => e.Entity as IModelBase))
            {
                history.ModifyTime = DateTime.Now;
                if (history.CreateTime == DateTime.MinValue)
                {
                    history.CreateTime = DateTime.Now;
                }
            }
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var history in this.ChangeTracker.Entries().Where(e => e.Entity is IModelBase && (e.State == EntityState.Added || e.State == EntityState.Modified)).Select(e => e.Entity as IModelBase))
            {
                history.ModifyTime = DateTime.Now;
                if (history.CreateTime == DateTime.MinValue)
                {
                    history.CreateTime = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
