using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SkyNet.Data;

namespace SkyNet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160718120654_initentity")]
    partial class initentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SkyNet.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AvatarUrl");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("Motto");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("FromUserId")
                        .IsRequired();

                    b.Property<DateTime>("ModifyTime");

                    b.Property<int>("PublicationId");

                    b.Property<string>("ToUserId");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("PublicationId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Description");

                    b.Property<int?>("FrontCoverMediaId");

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FrontCoverMediaId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.EventNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<decimal>("Cost");

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("EventId");

                    b.Property<bool>("HasCost");

                    b.Property<bool>("IsPublic");

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("EventNodes");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<int?>("EventNodeId");

                    b.Property<string>("MediaDescription");

                    b.Property<string>("MediaTypeName")
                        .IsRequired();

                    b.Property<string>("MediaUrl");

                    b.Property<DateTime>("ModifyTime");

                    b.HasKey("Id");

                    b.HasIndex("EventNodeId");

                    b.HasIndex("MediaTypeName");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.MediaType", b =>
                {
                    b.Property<string>("MediaTypeName");

                    b.Property<string>("MediaTypeDescription");

                    b.HasKey("MediaTypeName");

                    b.ToTable("MediaTypes");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Description");

                    b.Property<int>("EventId");

                    b.Property<int?>("FrontCoverMediaId");

                    b.Property<DateTime>("ModifyTime");

                    b.Property<int?>("OriginalHtmlId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("FrontCoverMediaId");

                    b.HasIndex("OriginalHtmlId");

                    b.HasIndex("UserId");

                    b.ToTable("Pulications");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.PublicationTag", b =>
                {
                    b.Property<int>("PublicationId");

                    b.Property<string>("TagName");

                    b.Property<int>("Id");

                    b.HasKey("PublicationId", "TagName");

                    b.HasIndex("PublicationId");

                    b.HasIndex("TagName");

                    b.ToTable("PublicationTags");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.Tag", b =>
                {
                    b.Property<string>("TagName");

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("ModifyTime");

                    b.HasKey("TagName");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.UserEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("EventId");

                    b.Property<bool>("IsOwner");

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("UserEvents");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SkyNet.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SkyNet.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkyNet.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.Comment", b =>
                {
                    b.HasOne("SkyNet.Models.ApplicationUser", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkyNet.Models.BusinessModels.Publication", "Publication")
                        .WithMany("Comments")
                        .HasForeignKey("PublicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkyNet.Models.ApplicationUser", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.Event", b =>
                {
                    b.HasOne("SkyNet.Models.BusinessModels.Media", "FrontCoverMedia")
                        .WithMany()
                        .HasForeignKey("FrontCoverMediaId");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.EventNode", b =>
                {
                    b.HasOne("SkyNet.Models.BusinessModels.Event", "Event")
                        .WithMany("EventNodes")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkyNet.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.Media", b =>
                {
                    b.HasOne("SkyNet.Models.BusinessModels.EventNode")
                        .WithMany("Medias")
                        .HasForeignKey("EventNodeId");

                    b.HasOne("SkyNet.Models.BusinessModels.MediaType", "MediaType")
                        .WithMany()
                        .HasForeignKey("MediaTypeName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.Publication", b =>
                {
                    b.HasOne("SkyNet.Models.BusinessModels.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkyNet.Models.BusinessModels.Media", "FrontCoverMedia")
                        .WithMany()
                        .HasForeignKey("FrontCoverMediaId");

                    b.HasOne("SkyNet.Models.BusinessModels.Media", "OriginalHtml")
                        .WithMany()
                        .HasForeignKey("OriginalHtmlId");

                    b.HasOne("SkyNet.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.PublicationTag", b =>
                {
                    b.HasOne("SkyNet.Models.BusinessModels.Publication", "Publication")
                        .WithMany("PublicationTags")
                        .HasForeignKey("PublicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkyNet.Models.BusinessModels.Tag", "Tag")
                        .WithMany("PublicationTags")
                        .HasForeignKey("TagName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SkyNet.Models.BusinessModels.UserEvent", b =>
                {
                    b.HasOne("SkyNet.Models.BusinessModels.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkyNet.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
