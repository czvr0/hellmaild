﻿// <auto-generated />
using System;
using HellMail.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HellMail.Data.Migrations
{
    [DbContext(typeof(HellMailContext))]
    partial class HellMailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HellMail.Domain.Hidden_Mails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("hidden")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int?>("mail_id");

                    b.Property<int?>("owner_id");

                    b.HasKey("id");

                    b.HasIndex("mail_id");

                    b.HasIndex("owner_id");

                    b.ToTable("Hidden_Mails");
                });

            modelBuilder.Entity("HellMail.Domain.Mail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("message");

                    b.Property<string>("subject");

                    b.HasKey("id");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("HellMail.Domain.Mail_User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("from_user_id");

                    b.Property<int>("hidden");

                    b.Property<int?>("mail_id");

                    b.Property<int>("recipient_type")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int?>("to_user_id");

                    b.HasKey("id");

                    b.HasIndex("from_user_id");

                    b.HasIndex("mail_id");

                    b.HasIndex("to_user_id");

                    b.ToTable("Mails_Users");
                });

            modelBuilder.Entity("HellMail.Domain.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("firstname");

                    b.Property<string>("password");

                    b.Property<string>("surname");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HellMail.Domain.Hidden_Mails", b =>
                {
                    b.HasOne("HellMail.Domain.Mail", "mail_")
                        .WithMany()
                        .HasForeignKey("mail_id");

                    b.HasOne("HellMail.Domain.User", "owner_")
                        .WithMany()
                        .HasForeignKey("owner_id");
                });

            modelBuilder.Entity("HellMail.Domain.Mail_User", b =>
                {
                    b.HasOne("HellMail.Domain.User", "from_user_")
                        .WithMany()
                        .HasForeignKey("from_user_id");

                    b.HasOne("HellMail.Domain.Mail", "mail_")
                        .WithMany()
                        .HasForeignKey("mail_id");

                    b.HasOne("HellMail.Domain.User", "to_user_")
                        .WithMany()
                        .HasForeignKey("to_user_id");
                });
#pragma warning restore 612, 618
        }
    }
}
