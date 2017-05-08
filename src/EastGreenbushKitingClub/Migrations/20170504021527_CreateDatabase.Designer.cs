using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EastGreenbushKitingClub.Models;

namespace EastGreenbushKitingClub.Migrations
{
    [DbContext(typeof(EastGreenbushKitingClubDbContext))]
    [Migration("20170504021527_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EastGreenbushKitingClub.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Details")
                        .HasMaxLength(1000);

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsArchived");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EastGreenbushKitingClub.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateJoined");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsArchived");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("StreetAddress2")
                        .HasMaxLength(100);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("EastGreenbushKitingClub.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsArchived");

                    b.Property<int>("MemberId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EastGreenbushKitingClub.Models.Post", b =>
                {
                    b.HasOne("EastGreenbushKitingClub.Models.Member")
                        .WithMany("Posts")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
