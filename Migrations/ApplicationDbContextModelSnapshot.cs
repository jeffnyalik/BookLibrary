﻿// <auto-generated />
using System;
using BookLibrary.AppContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookLibrary.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BookLibrary.Data.Models.Book_Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("authorId")
                        .HasColumnType("int");

                    b.Property<int>("bookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("authorId");

                    b.HasIndex("bookId");

                    b.ToTable("Books_Authors");
                });

            modelBuilder.Entity("BookLibrary.Data.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("BookLibrary.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookLibrary.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("bookTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("coverUrl")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("dateRead")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .HasColumnType("longtext");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("isRead")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("publishedYear")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("publisherId")
                        .HasColumnType("int");

                    b.Property<int>("rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("publisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookLibrary.Data.Models.Book_Author", b =>
                {
                    b.HasOne("BookLibrary.Models.Author", "Author")
                        .WithMany("Book_Authors")
                        .HasForeignKey("authorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookLibrary.Models.Book", "Book")
                        .WithMany("Book_Authors")
                        .HasForeignKey("bookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookLibrary.Models.Book", b =>
                {
                    b.HasOne("BookLibrary.Data.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("publisherId");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BookLibrary.Data.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookLibrary.Models.Author", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("BookLibrary.Models.Book", b =>
                {
                    b.Navigation("Book_Authors");
                });
#pragma warning restore 612, 618
        }
    }
}
