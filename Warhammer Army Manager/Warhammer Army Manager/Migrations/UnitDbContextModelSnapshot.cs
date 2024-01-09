﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warhammer_Army_Manager.Database;

#nullable disable

namespace Warhammer_Army_Manager.Migrations
{
    [DbContext(typeof(UnitDbContext))]
    partial class UnitDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("ArmysUnit", b =>
                {
                    b.Property<int>("ArmysId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArmysId", "UnitsId");

                    b.HasIndex("UnitsId");

                    b.ToTable("ArmysUnit");
                });

            modelBuilder.Entity("KeywordsUnit", b =>
                {
                    b.Property<int>("KeywordsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KeywordsId", "UnitsId");

                    b.HasIndex("UnitsId");

                    b.ToTable("KeywordsUnit");
                });

            modelBuilder.Entity("UnitWeapons", b =>
                {
                    b.Property<int>("UnitsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WeaponsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UnitsId", "WeaponsId");

                    b.HasIndex("WeaponsId");

                    b.ToTable("UnitWeapons");
                });

            modelBuilder.Entity("Warhammer_Army_Manager.Database.Models.Armys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Armys");
                });

            modelBuilder.Entity("Warhammer_Army_Manager.Database.Models.Keywords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("Warhammer_Army_Manager.Database.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bravery")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Move")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Save")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<int>("Wounds")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Warhammer_Army_Manager.Database.Models.Weapons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Attacks")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<string>("Damage")
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Range")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Rend")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpecialEffect")
                        .HasColumnType("TEXT");

                    b.Property<string>("ToHit")
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<string>("ToWound")
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("ArmysUnit", b =>
                {
                    b.HasOne("Warhammer_Army_Manager.Database.Models.Armys", null)
                        .WithMany()
                        .HasForeignKey("ArmysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warhammer_Army_Manager.Database.Models.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KeywordsUnit", b =>
                {
                    b.HasOne("Warhammer_Army_Manager.Database.Models.Keywords", null)
                        .WithMany()
                        .HasForeignKey("KeywordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warhammer_Army_Manager.Database.Models.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UnitWeapons", b =>
                {
                    b.HasOne("Warhammer_Army_Manager.Database.Models.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warhammer_Army_Manager.Database.Models.Weapons", null)
                        .WithMany()
                        .HasForeignKey("WeaponsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
