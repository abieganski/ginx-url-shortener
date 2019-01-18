﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ginx.me.Entities;

namespace ginx.me.Migrations.GinxMeDb
{
    [DbContext(typeof(GinxMeDbContext))]
    [Migration("20181226194951_SaltInShortenedUrlInstsance")]
    partial class SaltInShortenedUrlInstsance
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ginx.me.Entities.ShortenedUrlInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OriginalUrl");

                    b.Property<string>("Salt");

                    b.Property<string>("ShortenedUrl");

                    b.Property<string>("UniqueId");

                    b.Property<DateTime>("WhenCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("UniqueId")
                        .IsUnique()
                        .HasFilter("[UniqueId] IS NOT NULL");

                    b.ToTable("ShortenedUrlInstances");
                });
#pragma warning restore 612, 618
        }
    }
}
