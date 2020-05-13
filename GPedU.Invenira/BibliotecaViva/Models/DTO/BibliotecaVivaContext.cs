using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BibliotecaViva.Models.DTO
{
    public partial class BibliotecaVivaContext : DbContext
    {
        public BibliotecaVivaContext()
        {
        }

        public BibliotecaVivaContext(DbContextOptions<BibliotecaVivaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aplicacao> Aplicacao { get; set; }
        public virtual DbSet<Registro> Registro { get; set; }
        public virtual DbSet<Registro3d> Registro3d { get; set; }
        public virtual DbSet<Registroaudio> Registroaudio { get; set; }
        public virtual DbSet<Registroimagem> Registroimagem { get; set; }
        public virtual DbSet<Registrolink> Registrolink { get; set; }
        public virtual DbSet<Registrotexto> Registrotexto { get; set; }
        public virtual DbSet<Registrovideo> Registrovideo { get; set; }
        public virtual DbSet<Trilha> Trilha { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aplicacao>(entity =>
            {
                entity.HasKey(e => e.Codaplicacao)
                    .HasName("aplicacao_pkey");

                entity.ToTable("aplicacao");

                entity.HasIndex(e => e.Nomeaplicacao)
                    .HasName("aplicacao_nomeaplicacao_key")
                    .IsUnique();

                entity.Property(e => e.Codaplicacao).HasColumnName("codaplicacao");

                entity.Property(e => e.Nomeaplicacao)
                    .IsRequired()
                    .HasColumnName("nomeaplicacao")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.HasKey(e => e.Codregistro)
                    .HasName("registro_pkey");

                entity.ToTable("registro");

                entity.HasIndex(e => e.Codaplicacao)
                    .HasName("ifk_rel_09");

                entity.HasIndex(e => e.Codtrilha)
                    .HasName("ifk_rel_06");

                entity.HasIndex(e => e.Tituloregistro)
                    .HasName("registro_tituloregistro_key")
                    .IsUnique();

                entity.Property(e => e.Codregistro).HasColumnName("codregistro");

                entity.Property(e => e.Codaplicacao).HasColumnName("codaplicacao");

                entity.Property(e => e.Codtrilha).HasColumnName("codtrilha");

                entity.Property(e => e.Dataregistro)
                    .HasColumnName("dataregistro")
                    .HasColumnType("date");

                entity.Property(e => e.Sinopseregistro)
                    .HasColumnName("sinopseregistro")
                    .HasMaxLength(200);

                entity.Property(e => e.Tituloregistro)
                    .IsRequired()
                    .HasColumnName("tituloregistro")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodaplicacaoNavigation)
                    .WithMany(p => p.Registro)
                    .HasForeignKey(d => d.Codaplicacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registro_codaplicacao_fkey");

                entity.HasOne(d => d.CodtrilhaNavigation)
                    .WithMany(p => p.Registro)
                    .HasForeignKey(d => d.Codtrilha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registro_codtrilha_fkey");
            });

            modelBuilder.Entity<Registro3d>(entity =>
            {
                entity.HasKey(e => e.Codregistro3d)
                    .HasName("registro3d_pkey");

                entity.ToTable("registro3d");

                entity.HasIndex(e => e.Codregistro)
                    .HasName("ifk_rel_08");

                entity.HasIndex(e => e.Titloregistro)
                    .HasName("registro3d_titloregistro_key")
                    .IsUnique();

                entity.Property(e => e.Codregistro3d).HasColumnName("codregistro3d");

                entity.Property(e => e.Codregistro).HasColumnName("codregistro");

                entity.Property(e => e.Regsitro3dbase64).HasColumnName("regsitro3dbase64");

                entity.Property(e => e.Titloregistro)
                    .IsRequired()
                    .HasColumnName("titloregistro")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodregistroNavigation)
                    .WithMany(p => p.Registro3d)
                    .HasForeignKey(d => d.Codregistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registro3d_codregistro_fkey");
            });

            modelBuilder.Entity<Registroaudio>(entity =>
            {
                entity.HasKey(e => e.Codaudio)
                    .HasName("registroaudio_pkey");

                entity.ToTable("registroaudio");

                entity.HasIndex(e => e.Codregistro)
                    .HasName("ifk_rel_03");

                entity.HasIndex(e => e.Tituloaudio)
                    .HasName("registroaudio_tituloaudio_key")
                    .IsUnique();

                entity.Property(e => e.Codaudio).HasColumnName("codaudio");

                entity.Property(e => e.Audiobase64)
                    .IsRequired()
                    .HasColumnName("audiobase64");

                entity.Property(e => e.Codregistro).HasColumnName("codregistro");

                entity.Property(e => e.Tituloaudio)
                    .IsRequired()
                    .HasColumnName("tituloaudio")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodregistroNavigation)
                    .WithMany(p => p.Registroaudio)
                    .HasForeignKey(d => d.Codregistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registroaudio_codregistro_fkey");
            });

            modelBuilder.Entity<Registroimagem>(entity =>
            {
                entity.HasKey(e => e.Codimagem)
                    .HasName("registroimagem_pkey");

                entity.ToTable("registroimagem");

                entity.HasIndex(e => e.Codregistro)
                    .HasName("ifk_rel_04");

                entity.HasIndex(e => e.Tituloimagem)
                    .HasName("registroimagem_tituloimagem_key")
                    .IsUnique();

                entity.Property(e => e.Codimagem).HasColumnName("codimagem");

                entity.Property(e => e.Codregistro).HasColumnName("codregistro");

                entity.Property(e => e.Imagembase64).HasColumnName("imagembase64");

                entity.Property(e => e.Tituloimagem)
                    .IsRequired()
                    .HasColumnName("tituloimagem")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodregistroNavigation)
                    .WithMany(p => p.Registroimagem)
                    .HasForeignKey(d => d.Codregistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registroimagem_codregistro_fkey");
            });

            modelBuilder.Entity<Registrolink>(entity =>
            {
                entity.HasKey(e => e.Codlink)
                    .HasName("registrolink_pkey");

                entity.ToTable("registrolink");

                entity.HasIndex(e => e.Codregistro)
                    .HasName("ifk_rel_05");

                entity.HasIndex(e => e.Titulolink)
                    .HasName("registrolink_titulolink_key")
                    .IsUnique();

                entity.Property(e => e.Codlink).HasColumnName("codlink");

                entity.Property(e => e.Codregistro).HasColumnName("codregistro");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnName("link")
                    .HasMaxLength(100);

                entity.Property(e => e.Titulolink)
                    .IsRequired()
                    .HasColumnName("titulolink")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodregistroNavigation)
                    .WithMany(p => p.Registrolink)
                    .HasForeignKey(d => d.Codregistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registrolink_codregistro_fkey");
            });

            modelBuilder.Entity<Registrotexto>(entity =>
            {
                entity.HasKey(e => e.Codtexto)
                    .HasName("registrotexto_pkey");

                entity.ToTable("registrotexto");

                entity.HasIndex(e => e.Codregistro)
                    .HasName("ifk_rel_02");

                entity.HasIndex(e => e.Titulotexto)
                    .HasName("registrotexto_titulotexto_key")
                    .IsUnique();

                entity.Property(e => e.Codtexto).HasColumnName("codtexto");

                entity.Property(e => e.Codregistro).HasColumnName("codregistro");

                entity.Property(e => e.Texto).HasColumnName("texto");

                entity.Property(e => e.Titulotexto)
                    .IsRequired()
                    .HasColumnName("titulotexto")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodregistroNavigation)
                    .WithMany(p => p.Registrotexto)
                    .HasForeignKey(d => d.Codregistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registrotexto_codregistro_fkey");
            });

            modelBuilder.Entity<Registrovideo>(entity =>
            {
                entity.HasKey(e => e.Codvideo)
                    .HasName("registrovideo_pkey");

                entity.ToTable("registrovideo");

                entity.HasIndex(e => e.Codregistro)
                    .HasName("ifk_rel_01");

                entity.HasIndex(e => e.Titulovideo)
                    .HasName("registrovideo_titulovideo_key")
                    .IsUnique();

                entity.Property(e => e.Codvideo).HasColumnName("codvideo");

                entity.Property(e => e.Codregistro).HasColumnName("codregistro");

                entity.Property(e => e.Titulovideo)
                    .IsRequired()
                    .HasColumnName("titulovideo")
                    .HasMaxLength(50);

                entity.Property(e => e.Videobase64)
                    .IsRequired()
                    .HasColumnName("videobase64");

                entity.HasOne(d => d.CodregistroNavigation)
                    .WithMany(p => p.Registrovideo)
                    .HasForeignKey(d => d.Codregistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registrovideo_codregistro_fkey");
            });

            modelBuilder.Entity<Trilha>(entity =>
            {
                entity.HasKey(e => e.Codtrilha)
                    .HasName("trilha_pkey");

                entity.ToTable("trilha");

                entity.HasIndex(e => e.Nometrilha)
                    .HasName("trilha_nometrilha_key")
                    .IsUnique();

                entity.Property(e => e.Codtrilha).HasColumnName("codtrilha");

                entity.Property(e => e.Nometrilha)
                    .IsRequired()
                    .HasColumnName("nometrilha")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
