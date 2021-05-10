﻿// <auto-generated />
using System;
using App.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace App.Infra.Data.Migrations.PgSql
{
    [DbContext(typeof(DbAppContext))]
    [Migration("20210510023231_filtro")]
    partial class filtro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("App.Domain.Apartamentos.Entities.Apartamento", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Andar")
                        .HasColumnType("integer");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp");

                    b.Property<Guid>("BlocoId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CadastradoEm")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletadoEm")
                        .HasColumnType("timestamp");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BlocoId");

                    b.ToTable("Apartamento");
                });

            modelBuilder.Entity("App.Domain.Blocos.Entities.Bloco", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CadastradoEm")
                        .HasColumnType("timestamp");

                    b.Property<Guid>("CondominioId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletadoEm")
                        .HasColumnType("timestamp");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.ToTable("Bloco");
                });

            modelBuilder.Entity("App.Domain.Condominios.Entities.Condominio", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CadastradoEm")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletadoEm")
                        .HasColumnType("timestamp");

                    b.Property<string>("EmailSindico")
                        .HasColumnType("varchar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Condominio");
                });

            modelBuilder.Entity("App.Domain.Pessoas.Entities.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ApartamentoId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("CadastradoEm")
                        .HasColumnType("timestamp");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeletadoEm")
                        .HasColumnType("timestamp");

                    b.Property<string>("Email")
                        .HasColumnType("varchar");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("ApartamentoId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("App.Domain.Apartamentos.Entities.Apartamento", b =>
                {
                    b.HasOne("App.Domain.Blocos.Entities.Bloco", "Bloco")
                        .WithMany("Apartamentos")
                        .HasForeignKey("BlocoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bloco");
                });

            modelBuilder.Entity("App.Domain.Blocos.Entities.Bloco", b =>
                {
                    b.HasOne("App.Domain.Condominios.Entities.Condominio", "Condominio")
                        .WithMany("Blocos")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Condominio");
                });

            modelBuilder.Entity("App.Domain.Pessoas.Entities.Pessoa", b =>
                {
                    b.HasOne("App.Domain.Apartamentos.Entities.Apartamento", "Apartamento")
                        .WithMany("Pessoas")
                        .HasForeignKey("ApartamentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Apartamento");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Domain.Apartamentos.Entities.Apartamento", b =>
                {
                    b.Navigation("Pessoas");
                });

            modelBuilder.Entity("App.Domain.Blocos.Entities.Bloco", b =>
                {
                    b.Navigation("Apartamentos");
                });

            modelBuilder.Entity("App.Domain.Condominios.Entities.Condominio", b =>
                {
                    b.Navigation("Blocos");
                });
#pragma warning restore 612, 618
        }
    }
}
