// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiplexApis.Data;

namespace MultiplexApis.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220319110825_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Models.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("DataAccessLayer.Models.MultiMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieId1")
                        .HasColumnType("int");

                    b.Property<string>("MultiplexId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MultiplexId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId1");

                    b.HasIndex("MultiplexId1");

                    b.ToTable("MultiMovie");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Multiplex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Multiplex");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Screens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MultiplexId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MultiplexId");

                    b.ToTable("Screens");
                });

            modelBuilder.Entity("DataAccessLayer.Models.MultiMovie", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Movies", "Movie")
                        .WithMany("ListMultiplex")
                        .HasForeignKey("MovieId1");

                    b.HasOne("DataAccessLayer.Models.Multiplex", "Multiplex")
                        .WithMany("ListMovies")
                        .HasForeignKey("MultiplexId1");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Screens", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Multiplex", "Multiplex")
                        .WithMany("Screens")
                        .HasForeignKey("MultiplexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
