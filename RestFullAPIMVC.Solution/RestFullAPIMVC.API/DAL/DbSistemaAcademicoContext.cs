using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestFullAPIMVC.API.Models;

namespace RestFullAPIMVC.API.DAL
{
    public partial class DbSistemaAcademicoContext : DbContext
    {
        public DbSistemaAcademicoContext()
        {
        }

        public DbSistemaAcademicoContext(DbContextOptions<DbSistemaAcademicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; } = null!;
        public virtual DbSet<Boleto> Boletos { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-02BUU56;Initial Catalog=DbSistemaAcademico;Integrated Security=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PK__Aluno__8092FCB33AC61EE7");
            });

            modelBuilder.Entity<Boleto>(entity =>
            {
                entity.HasKey(e => e.IdBoleto)
                    .HasName("PK__Boleto__362F6EA0D43CAA45");

                entity.Property(e => e.Status).HasDefaultValueSql("('Pendente')");

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.Boletos)
                    .HasForeignKey(d => d.IdMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Boleto__IdMatric__412EB0B6");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__085F27D682F25C77");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.IdMatricula)
                    .HasName("PK__Matricul__AD06C20FB86F020A");

                entity.Property(e => e.Status).HasDefaultValueSql("('Ativa')");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matricula__IdAlu__3C69FB99");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matricula__IdCur__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
