﻿// <auto-generated />
using System;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221024100512_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LibraryAPI.Models.Entities.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DbTables")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("DbTables");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("Description");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("IP");

                    b.Property<int>("Operation")
                        .HasColumnType("integer")
                        .HasColumnName("Operation");

                    b.Property<string>("TableRowId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TableRowId");

                    b.Property<DateTime>("Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(4677))
                        .HasColumnName("Time");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Audits", (string)null);
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorFirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("AuthorFirstName");

                    b.Property<string>("AuthorLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("AuthorLastName");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("Description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.BookInLibrary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("BookId");

                    b.Property<int>("NumOfAvailable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("NumOfAvailable");

                    b.Property<int>("NumOfRented")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("NumOfRented");

                    b.Property<int>("TotalBooks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("TotalBooks");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BooksInLibrary", (string)null);
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("City");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("FirstName");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("LastName");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)")
                        .HasColumnName("PostalCode");

                    b.Property<string>("State")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("State");

                    b.Property<string>("StreetAddress")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("StreetAddress");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Persons", (string)null);
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.SecurityAudit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("Description");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("IP");

                    b.Property<DateTime>("LogTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(6120))
                        .HasColumnName("LogTime");

                    b.Property<Guid?>("OperatorUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("OperatorUserId");

                    b.Property<string>("OperatorUserRole")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("OperatorUserRole");

                    b.Property<string>("OperatorUserUsername")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("OperatorUserUsername");

                    b.Property<int>("SecurityOperation")
                        .HasColumnType("integer")
                        .HasColumnName("SecurityOperation");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OperatorUserId");

                    b.HasIndex("UserId");

                    b.ToTable("SecurityAudit", (string)null);
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("IpAddress");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("StartTime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SESSIONS", (string)null);
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<int>("CurrUserCredentialId")
                        .HasColumnType("integer")
                        .HasColumnName("CurrUserCredentialId");

                    b.Property<bool>("IsConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("IsConfirmed");

                    b.Property<bool>("IsEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("IsEnabled");

                    b.Property<bool>("IsLocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("IsLocked");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid")
                        .HasColumnName("PersonId");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.UserBookRented", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("BookId");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("EndDate");

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(7847))
                        .HasColumnName("StartDate");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersBooksRented", (string)null);
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.UserCredential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(8907))
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("ExpiredDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ExpiredDate");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("IP");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Password");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersCredentials", (string)null);
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.Audit", b =>
                {
                    b.HasOne("LibraryAPI.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.BookInLibrary", b =>
                {
                    b.HasOne("LibraryAPI.Models.Entities.Book", "Book")
                        .WithOne("BookInLibrary")
                        .HasForeignKey("LibraryAPI.Models.Entities.BookInLibrary", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.SecurityAudit", b =>
                {
                    b.HasOne("LibraryAPI.Models.Entities.User", "OperatorUser")
                        .WithMany()
                        .HasForeignKey("OperatorUserId");

                    b.HasOne("LibraryAPI.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperatorUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.Session", b =>
                {
                    b.HasOne("LibraryAPI.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.User", b =>
                {
                    b.HasOne("LibraryAPI.Models.Entities.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("LibraryAPI.Models.Entities.User", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.UserBookRented", b =>
                {
                    b.HasOne("LibraryAPI.Models.Entities.Book", "Book")
                        .WithMany("UserBookRented")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryAPI.Models.Entities.User", "User")
                        .WithMany("UserBookRented")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.UserCredential", b =>
                {
                    b.HasOne("LibraryAPI.Models.Entities.User", "User")
                        .WithMany("UserCredentials")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.Book", b =>
                {
                    b.Navigation("BookInLibrary")
                        .IsRequired();

                    b.Navigation("UserBookRented");
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.Person", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryAPI.Models.Entities.User", b =>
                {
                    b.Navigation("UserBookRented");

                    b.Navigation("UserCredentials");
                });
#pragma warning restore 612, 618
        }
    }
}
