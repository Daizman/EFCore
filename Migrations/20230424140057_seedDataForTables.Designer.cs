﻿// <auto-generated />
using System;
using EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.Migrations
{
    [DbContext(typeof(EFCoreContext))]
    [Migration("20230424140057_seedDataForTables")]
    partial class seedDataForTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<Guid>("AuthorsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BooksId")
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("AuthorPublisher", b =>
                {
                    b.Property<Guid>("AuthorsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PublishersId")
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorsId", "PublishersId");

                    b.HasIndex("PublishersId");

                    b.ToTable("AuthorPublisher");
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("TEXT");

                    b.Property<int>("GenresId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BooksId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("BookGenre");
                });

            modelBuilder.Entity("EFCore.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c245bdfd-d306-42dc-8c69-ba5980bb9364"),
                            BirthDate = new DateOnly(1799, 6, 6),
                            Fio = "Пушкин А.С."
                        },
                        new
                        {
                            Id = new Guid("519201cb-6fd8-4cd8-b06d-0e4523c91e48"),
                            BirthDate = new DateOnly(1821, 10, 30),
                            Fio = "Достоевский Ф.М."
                        },
                        new
                        {
                            Id = new Guid("cf6b1fa1-5a2b-4bc4-b2bb-49e2d3163594"),
                            BirthDate = new DateOnly(1828, 8, 28),
                            Fio = "Толстой Л.Н."
                        },
                        new
                        {
                            Id = new Guid("ffaaeb53-ce11-443a-b6b9-bcd5666936fa"),
                            BirthDate = new DateOnly(1860, 1, 17),
                            Fio = "Чехов А.П."
                        });
                });

            modelBuilder.Entity("EFCore.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("PublishDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Book");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EFCore.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ужасы"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Комедия"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Детектив"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Триллер"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Спорт"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Драма"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Романтика"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Фэнтези"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Приключения"
                        });
                });

            modelBuilder.Entity("EFCore.Models.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2af9b647-3dd3-424d-b1e1-97eb4bda5daa"),
                            Name = "Pinguin"
                        },
                        new
                        {
                            Id = new Guid("828082d7-4da9-49c3-805a-efc2772b51af"),
                            Name = "Harper Collins"
                        },
                        new
                        {
                            Id = new Guid("222f3ced-4584-46d6-965f-4aeb8b13c158"),
                            Name = "Macmillan"
                        });
                });

            modelBuilder.Entity("EFCore.Models.Journal", b =>
                {
                    b.HasBaseType("EFCore.Models.Book");

                    b.Property<int>("Edition")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Journal");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("EFCore.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthorPublisher", b =>
                {
                    b.HasOne("EFCore.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.Models.Publisher", null)
                        .WithMany()
                        .HasForeignKey("PublishersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("EFCore.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCore.Models.Book", b =>
                {
                    b.HasOne("EFCore.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("EFCore.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
