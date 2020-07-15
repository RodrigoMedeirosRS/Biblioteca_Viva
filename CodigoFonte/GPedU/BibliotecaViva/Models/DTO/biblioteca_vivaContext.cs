using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BibliotecaViva.Models.DTO
{
    public partial class biblioteca_vivaContext : DbContext
    {
        public biblioteca_vivaContext()
        {
        }

        public biblioteca_vivaContext(DbContextOptions<biblioteca_vivaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apelido> Apelido { get; set; }
        public virtual DbSet<Audio> Audio { get; set; }
        public virtual DbSet<Audiodescricaoimagem> Audiodescricaoimagem { get; set; }
        public virtual DbSet<Audiodescricaovideo> Audiodescricaovideo { get; set; }
        public virtual DbSet<Conceito> Conceito { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Documentodossie> Documentodossie { get; set; }
        public virtual DbSet<Documentoglossario> Documentoglossario { get; set; }
        public virtual DbSet<Dossie> Dossie { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Eventodocumento> Eventodocumento { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Glossario> Glossario { get; set; }
        public virtual DbSet<Idioma> Idioma { get; set; }
        public virtual DbSet<Imagem> Imagem { get; set; }
        public virtual DbSet<Legenda> Legenda { get; set; }
        public virtual DbSet<Linhadotempo> Linhadotempo { get; set; }
        public virtual DbSet<Linhadotempodocumento> Linhadotempodocumento { get; set; }
        public virtual DbSet<Linhadotempoevento> Linhadotempoevento { get; set; }
        public virtual DbSet<Linhadotempopessoa> Linhadotempopessoa { get; set; }
        public virtual DbSet<Localevento> Localevento { get; set; }
        public virtual DbSet<Localglossario> Localglossario { get; set; }
        public virtual DbSet<Localizacao> Localizacao { get; set; }
        public virtual DbSet<Nomesocial> Nomesocial { get; set; }
        public virtual DbSet<Participacao> Participacao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Significado> Significado { get; set; }
        public virtual DbSet<Termo> Termo { get; set; }
        public virtual DbSet<Termopessoa> Termopessoa { get; set; }
        public virtual DbSet<Texto> Texto { get; set; }
        public virtual DbSet<Tipoevento> Tipoevento { get; set; }
        public virtual DbSet<Tipoparticipacao> Tipoparticipacao { get; set; }
        public virtual DbSet<Transcricao> Transcricao { get; set; }
        public virtual DbSet<Video> Video { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apelido>(entity =>
            {
                entity.ToTable("apelido");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("ifk_rel_31");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(20);

                entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Apelido)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("apelido_pessoa_id_fkey");
            });

            modelBuilder.Entity<Audio>(entity =>
            {
                entity.ToTable("audio");

                entity.HasIndex(e => e.DocumentoId)
                    .HasName("ifk_rel_17");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Base64)
                    .IsRequired()
                    .HasColumnName("base64");

                entity.Property(e => e.DocumentoId).HasColumnName("documento_id");

                entity.HasOne(d => d.Documento)
                    .WithMany(p => p.Audio)
                    .HasForeignKey(d => d.DocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("audio_documento_id_fkey");
            });

            modelBuilder.Entity<Audiodescricaoimagem>(entity =>
            {
                entity.ToTable("audiodescricaoimagem");

                entity.HasIndex(e => e.AudioId)
                    .HasName("ifk_rel_19");

                entity.HasIndex(e => e.IdiomaId)
                    .HasName("ifk_rel_42");

                entity.HasIndex(e => e.ImagemId)
                    .HasName("ifk_rel_41");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AudioId).HasColumnName("audio_id");

                entity.Property(e => e.IdiomaId).HasColumnName("idioma_id");

                entity.Property(e => e.ImagemId).HasColumnName("imagem_id");

                entity.HasOne(d => d.Audio)
                    .WithMany(p => p.Audiodescricaoimagem)
                    .HasForeignKey(d => d.AudioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("audiodescricaoimagem_audio_id_fkey");

                entity.HasOne(d => d.Idioma)
                    .WithMany(p => p.Audiodescricaoimagem)
                    .HasForeignKey(d => d.IdiomaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("audiodescricaoimagem_idioma_id_fkey");

                entity.HasOne(d => d.Imagem)
                    .WithMany(p => p.Audiodescricaoimagem)
                    .HasForeignKey(d => d.ImagemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("audiodescricaoimagem_imagem_id_fkey");
            });

            modelBuilder.Entity<Audiodescricaovideo>(entity =>
            {
                entity.ToTable("audiodescricaovideo");

                entity.HasIndex(e => e.AudioId)
                    .HasName("ifk_rel_15");

                entity.HasIndex(e => e.IdiomaId)
                    .HasName("ifk_rel_43");

                entity.HasIndex(e => e.VideoId)
                    .HasName("ifk_rel_18");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AudioId).HasColumnName("audio_id");

                entity.Property(e => e.IdiomaId).HasColumnName("idioma_id");

                entity.Property(e => e.VideoId).HasColumnName("video_id");

                entity.HasOne(d => d.Audio)
                    .WithMany(p => p.Audiodescricaovideo)
                    .HasForeignKey(d => d.AudioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("audiodescricaovideo_audio_id_fkey");

                entity.HasOne(d => d.Idioma)
                    .WithMany(p => p.Audiodescricaovideo)
                    .HasForeignKey(d => d.IdiomaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("audiodescricaovideo_idioma_id_fkey");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.Audiodescricaovideo)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("audiodescricaovideo_video_id_fkey");
            });

            modelBuilder.Entity<Conceito>(entity =>
            {
                entity.ToTable("conceito");

                entity.HasIndex(e => e.GlossarioId)
                    .HasName("ifk_rel_03");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GlossarioId).HasColumnName("glossario_id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Glossario)
                    .WithMany(p => p.Conceito)
                    .HasForeignKey(d => d.GlossarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("conceito_glossario_id_fkey");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.ToTable("documento");

                entity.HasIndex(e => e.Nome)
                    .HasName("documento_nome_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datadigitalizacao).HasColumnName("datadigitalizacao");

                entity.Property(e => e.Dataregistro).HasColumnName("dataregistro");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Documentodossie>(entity =>
            {
                entity.ToTable("documentodossie");

                entity.HasIndex(e => e.DocumentoId)
                    .HasName("ifk_rel_20");

                entity.HasIndex(e => e.DossieId)
                    .HasName("ifk_rel_09");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocumentoId).HasColumnName("documento_id");

                entity.Property(e => e.DossieId).HasColumnName("dossie_id");

                entity.HasOne(d => d.Documento)
                    .WithMany(p => p.Documentodossie)
                    .HasForeignKey(d => d.DocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("documentodossie_documento_id_fkey");

                entity.HasOne(d => d.Dossie)
                    .WithMany(p => p.Documentodossie)
                    .HasForeignKey(d => d.DossieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("documentodossie_dossie_id_fkey");
            });

            modelBuilder.Entity<Documentoglossario>(entity =>
            {
                entity.ToTable("documentoglossario");

                entity.HasIndex(e => e.DocumentoId)
                    .HasName("ifk_rel_23");

                entity.HasIndex(e => e.GlossarioId)
                    .HasName("ifk_rel_08");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocumentoId).HasColumnName("documento_id");

                entity.Property(e => e.GlossarioId).HasColumnName("glossario_id");

                entity.HasOne(d => d.Documento)
                    .WithMany(p => p.Documentoglossario)
                    .HasForeignKey(d => d.DocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("documentoglossario_documento_id_fkey");

                entity.HasOne(d => d.Glossario)
                    .WithMany(p => p.Documentoglossario)
                    .HasForeignKey(d => d.GlossarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("documentoglossario_glossario_id_fkey");
            });

            modelBuilder.Entity<Dossie>(entity =>
            {
                entity.ToTable("dossie");

                entity.HasIndex(e => e.DocumentoId)
                    .HasName("ifk_rel_10");

                entity.HasIndex(e => e.Nome)
                    .HasName("dossie_nome_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocumentoId).HasColumnName("documento_id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.HasOne(d => d.Documento)
                    .WithMany(p => p.Dossie)
                    .HasForeignKey(d => d.DocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dossie_documento_id_fkey");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("evento");

                entity.HasIndex(e => e.Nome)
                    .HasName("evento_nome_key")
                    .IsUnique();

                entity.HasIndex(e => e.TipoeventoId)
                    .HasName("ifk_rel_28");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datahora).HasColumnName("datahora");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100);

                entity.Property(e => e.TipoeventoId).HasColumnName("tipoevento_id");

                entity.HasOne(d => d.Tipoevento)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.TipoeventoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evento_tipoevento_id_fkey");
            });

            modelBuilder.Entity<Eventodocumento>(entity =>
            {
                entity.ToTable("eventodocumento");

                entity.HasIndex(e => e.DocumentoId)
                    .HasName("ifk_rel_21");

                entity.HasIndex(e => e.EventoId)
                    .HasName("ifk_rel_25");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocumentoId).HasColumnName("documento_id");

                entity.Property(e => e.EventoId).HasColumnName("evento_id");

                entity.HasOne(d => d.Documento)
                    .WithMany(p => p.Eventodocumento)
                    .HasForeignKey(d => d.DocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventodocumento_documento_id_fkey");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.Eventodocumento)
                    .HasForeignKey(d => d.EventoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eventodocumento_evento_id_fkey");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("genero");

                entity.HasIndex(e => e.Nome)
                    .HasName("genero_nome_key")
                    .IsUnique();

                entity.HasIndex(e => e.PessoaId)
                    .HasName("ifk_rel_32");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(20);

                entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Genero)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("genero_pessoa_id_fkey");
            });

            modelBuilder.Entity<Glossario>(entity =>
            {
                entity.ToTable("glossario");

                entity.HasIndex(e => e.Nome)
                    .HasName("glossario_nome_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.ToTable("idioma");

                entity.HasIndex(e => e.Nome)
                    .HasName("idioma_nome_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Imagem>(entity =>
            {
                entity.ToTable("imagem");

                entity.HasIndex(e => e.DocumentoId)
                    .HasName("ifk_rel_40");

                entity.HasIndex(e => e.TermoId)
                    .HasName("ifk_rel_39");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Base64)
                    .IsRequired()
                    .HasColumnName("base64");

                entity.Property(e => e.DocumentoId).HasColumnName("documento_id");

                entity.Property(e => e.TermoId).HasColumnName("termo_id");

                entity.HasOne(d => d.Documento)
                    .WithMany(p => p.Imagem)
                    .HasForeignKey(d => d.DocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("imagem_documento_id_fkey");

                entity.HasOne(d => d.Termo)
                    .WithMany(p => p.Imagem)
                    .HasForeignKey(d => d.TermoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("imagem_termo_id_fkey");
            });

            modelBuilder.Entity<Legenda>(entity =>
            {
                entity.ToTable("legenda");

                entity.HasIndex(e => e.TextoId)
                    .HasName("ifk_rel_12");

                entity.HasIndex(e => e.VideoId)
                    .HasName("ifk_rel_16");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TextoId).HasColumnName("texto_id");

                entity.Property(e => e.VideoId).HasColumnName("video_id");

                entity.HasOne(d => d.Texto)
                    .WithMany(p => p.Legenda)
                    .HasForeignKey(d => d.TextoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("legenda_texto_id_fkey");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.Legenda)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("legenda_video_id_fkey");
            });

            modelBuilder.Entity<Linhadotempo>(entity =>
            {
                entity.ToTable("linhadotempo");

                entity.HasIndex(e => e.Nome)
                    .HasName("linhadotempo_nome_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricacao)
                    .IsRequired()
                    .HasColumnName("descricacao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Linhadotempodocumento>(entity =>
            {
                entity.ToTable("linhadotempodocumento");

                entity.HasIndex(e => e.DocumentoId)
                    .HasName("ifk_rel_22");

                entity.HasIndex(e => e.LinhadotempoId)
                    .HasName("ifk_rel_36");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocumentoId).HasColumnName("documento_id");

                entity.Property(e => e.LinhadotempoId).HasColumnName("linhadotempo_id");

                entity.HasOne(d => d.Documento)
                    .WithMany(p => p.Linhadotempodocumento)
                    .HasForeignKey(d => d.DocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("linhadotempodocumento_documento_id_fkey");

                entity.HasOne(d => d.Linhadotempo)
                    .WithMany(p => p.Linhadotempodocumento)
                    .HasForeignKey(d => d.LinhadotempoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("linhadotempodocumento_linhadotempo_id_fkey");
            });

            modelBuilder.Entity<Linhadotempoevento>(entity =>
            {
                entity.ToTable("linhadotempoevento");

                entity.HasIndex(e => e.EventoId)
                    .HasName("ifk_rel_26");

                entity.HasIndex(e => e.LinhadotempoId)
                    .HasName("ifk_rel_24");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventoId).HasColumnName("evento_id");

                entity.Property(e => e.LinhadotempoId).HasColumnName("linhadotempo_id");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.Linhadotempoevento)
                    .HasForeignKey(d => d.EventoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("linhadotempoevento_evento_id_fkey");

                entity.HasOne(d => d.Linhadotempo)
                    .WithMany(p => p.Linhadotempoevento)
                    .HasForeignKey(d => d.LinhadotempoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("linhadotempoevento_linhadotempo_id_fkey");
            });

            modelBuilder.Entity<Linhadotempopessoa>(entity =>
            {
                entity.ToTable("linhadotempopessoa");

                entity.HasIndex(e => e.LinhadotempoId)
                    .HasName("ifk_rel_37");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("ifk_rel_35");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LinhadotempoId).HasColumnName("linhadotempo_id");

                entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");

                entity.HasOne(d => d.Linhadotempo)
                    .WithMany(p => p.Linhadotempopessoa)
                    .HasForeignKey(d => d.LinhadotempoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("linhadotempopessoa_linhadotempo_id_fkey");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Linhadotempopessoa)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("linhadotempopessoa_pessoa_id_fkey");
            });

            modelBuilder.Entity<Localevento>(entity =>
            {
                entity.ToTable("localevento");

                entity.HasIndex(e => e.EventoId)
                    .HasName("ifk_rel_07");

                entity.HasIndex(e => e.LocalizacaoId)
                    .HasName("ifk_rel_06");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventoId).HasColumnName("evento_id");

                entity.Property(e => e.LocalizacaoId).HasColumnName("localizacao_id");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.Localevento)
                    .HasForeignKey(d => d.EventoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("localevento_evento_id_fkey");

                entity.HasOne(d => d.Localizacao)
                    .WithMany(p => p.Localevento)
                    .HasForeignKey(d => d.LocalizacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("localevento_localizacao_id_fkey");
            });

            modelBuilder.Entity<Localglossario>(entity =>
            {
                entity.ToTable("localglossario");

                entity.HasIndex(e => e.GlossarioId)
                    .HasName("ifk_rel_04");

                entity.HasIndex(e => e.LocalizacaoId)
                    .HasName("ifk_rel_05");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GlossarioId).HasColumnName("glossario_id");

                entity.Property(e => e.LocalizacaoId).HasColumnName("localizacao_id");

                entity.HasOne(d => d.Glossario)
                    .WithMany(p => p.Localglossario)
                    .HasForeignKey(d => d.GlossarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("localglossario_glossario_id_fkey");

                entity.HasOne(d => d.Localizacao)
                    .WithMany(p => p.Localglossario)
                    .HasForeignKey(d => d.LocalizacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("localglossario_localizacao_id_fkey");
            });

            modelBuilder.Entity<Localizacao>(entity =>
            {
                entity.ToTable("localizacao");

                entity.HasIndex(e => e.Nome)
                    .HasName("localizacao_nome_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datahora).HasColumnName("datahora");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Nomesocial>(entity =>
            {
                entity.ToTable("nomesocial");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("ifk_rel_33");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(20);

                entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Nomesocial)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nomesocial_pessoa_id_fkey");
            });

            modelBuilder.Entity<Participacao>(entity =>
            {
                entity.ToTable("participacao");

                entity.HasIndex(e => e.EventoId)
                    .HasName("ifk_rel_27");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("ifk_rel_30");

                entity.HasIndex(e => e.TipoparticipacaoId)
                    .HasName("ifk_rel_29");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventoId).HasColumnName("evento_id");

                entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");

                entity.Property(e => e.TipoparticipacaoId).HasColumnName("tipoparticipacao_id");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.Participacao)
                    .HasForeignKey(d => d.EventoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("participacao_evento_id_fkey");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Participacao)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("participacao_pessoa_id_fkey");

                entity.HasOne(d => d.Tipoparticipacao)
                    .WithMany(p => p.Participacao)
                    .HasForeignKey(d => d.TipoparticipacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("participacao_tipoparticipacao_id_fkey");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa");

                entity.HasIndex(e => e.Sobrenome)
                    .HasName("pessoa_sobrenome_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(25);

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasColumnName("sobrenome")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Significado>(entity =>
            {
                entity.ToTable("significado");

                entity.HasIndex(e => e.ConceitoId)
                    .HasName("ifk_rel_01");

                entity.HasIndex(e => e.IdiomaId)
                    .HasName("ifk_rel_02");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConceitoId).HasColumnName("conceito_id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao");

                entity.Property(e => e.IdiomaId).HasColumnName("idioma_id");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Conceito)
                    .WithMany(p => p.Significado)
                    .HasForeignKey(d => d.ConceitoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("significado_conceito_id_fkey");

                entity.HasOne(d => d.Idioma)
                    .WithMany(p => p.Significado)
                    .HasForeignKey(d => d.IdiomaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("significado_idioma_id_fkey");
            });

            modelBuilder.Entity<Termo>(entity =>
            {
                entity.ToTable("termo");

                entity.HasIndex(e => e.Nome)
                    .HasName("termo_nome_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome).HasColumnName("nome");

                entity.Property(e => e.Texto).HasColumnName("texto");
            });

            modelBuilder.Entity<Termopessoa>(entity =>
            {
                entity.ToTable("termopessoa");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("ifk_rel_34");

                entity.HasIndex(e => e.TermoId)
                    .HasName("ifk_rel_38");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aceito).HasColumnName("aceito");

                entity.Property(e => e.PessoaId).HasColumnName("pessoa_id");

                entity.Property(e => e.TermoId).HasColumnName("termo_id");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Termopessoa)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("termopessoa_pessoa_id_fkey");

                entity.HasOne(d => d.Termo)
                    .WithMany(p => p.Termopessoa)
                    .HasForeignKey(d => d.TermoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("termopessoa_termo_id_fkey");
            });

            modelBuilder.Entity<Texto>(entity =>
            {
                entity.ToTable("texto");

                entity.HasIndex(e => e.DocumentoId)
                    .HasName("ifk_rel_11");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocumentoId).HasColumnName("documento_id");

                entity.Property(e => e.Texto1)
                    .IsRequired()
                    .HasColumnName("texto");

                entity.HasOne(d => d.Documento)
                    .WithMany(p => p.Texto)
                    .HasForeignKey(d => d.DocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("texto_documento_id_fkey");
            });

            modelBuilder.Entity<Tipoevento>(entity =>
            {
                entity.ToTable("tipoevento");

                entity.HasIndex(e => e.Nome)
                    .HasName("tipoevento_nome_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tipoparticipacao>(entity =>
            {
                entity.ToTable("tipoparticipacao");

                entity.HasIndex(e => e.Nome)
                    .HasName("tipoparticipacao_nome_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome).HasColumnName("nome");
            });

            modelBuilder.Entity<Transcricao>(entity =>
            {
                entity.ToTable("transcricao");

                entity.HasIndex(e => e.AudioId)
                    .HasName("ifk_rel_14");

                entity.HasIndex(e => e.TextoId)
                    .HasName("ifk_rel_13");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AudioId).HasColumnName("audio_id");

                entity.Property(e => e.TextoId).HasColumnName("texto_id");

                entity.HasOne(d => d.Audio)
                    .WithMany(p => p.Transcricao)
                    .HasForeignKey(d => d.AudioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transcricao_audio_id_fkey");

                entity.HasOne(d => d.Texto)
                    .WithMany(p => p.Transcricao)
                    .HasForeignKey(d => d.TextoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transcricao_texto_id_fkey");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("video");

                entity.HasIndex(e => e.DocumentoId)
                    .HasName("ifk_rel_19b");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DocumentoId).HasColumnName("documento_id");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Documento)
                    .WithMany(p => p.Video)
                    .HasForeignKey(d => d.DocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("video_documento_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
