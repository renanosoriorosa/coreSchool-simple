﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using coreSchoolSimple.Models;

namespace coreSchoolSimple.Migrations
{
    [DbContext(typeof(coreSchoolSimpleContext))]
    partial class coreSchoolSimpleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("coreSchoolSimple.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataNasc");

                    b.Property<string>("Nome");

                    b.Property<double>("Nota");

                    b.Property<int>("ProfessorId");

                    b.Property<int>("TurmaId");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("coreSchoolSimple.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("coreSchoolSimple.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Curso");

                    b.Property<int>("Numero");

                    b.HasKey("Id");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("coreSchoolSimple.Models.Aluno", b =>
                {
                    b.HasOne("coreSchoolSimple.Models.Professor", "Professor")
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coreSchoolSimple.Models.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
