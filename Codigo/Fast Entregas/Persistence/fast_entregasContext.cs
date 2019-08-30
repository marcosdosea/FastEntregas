using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence
{
    public partial class fast_entregasContext : DbContext
    {
        public fast_entregasContext()
        {
        }

        public fast_entregasContext(DbContextOptions<fast_entregasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<Cartao> Cartao { get; set; }
        public virtual DbSet<ContaBancaria> ContaBancaria { get; set; }
        public virtual DbSet<Entrega> Entrega { get; set; }
        public virtual DbSet<Formaspagamento> Formaspagamento { get; set; }
        public virtual DbSet<FormaspagamentoHasEntrega> FormaspagamentoHasEntrega { get; set; }
        public virtual DbSet<SolicitacaoDeCadastro> SolicitacaoDeCadastro { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioVeiculo> UsuarioVeiculo { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=fast_entregas");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims", "fast_entregas");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClaimType).IsUnicode(false);

                entity.Property(e => e.ClaimValue).IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles", "fast_entregas");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ConcurrencyStamp).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims", "fast_entregas");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClaimType).IsUnicode(false);

                entity.Property(e => e.ClaimValue).IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("aspnetuserlogins", "fast_entregas");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderKey)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderDisplayName).IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("aspnetuserroles", "fast_entregas");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.RoleId).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers", "fast_entregas");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.SecurityStamp).IsUnicode(false);

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("aspnetusertokens", "fast_entregas");

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Value).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.HasKey(e => e.CodBanco);

                entity.ToTable("banco", "fast_entregas");

                entity.Property(e => e.CodBanco)
                    .HasColumnName("codBanco")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cartao>(entity =>
            {
                entity.HasKey(e => e.CodCartao);

                entity.ToTable("cartao", "fast_entregas");

                entity.HasIndex(e => e.CodUsuario)
                    .HasName("fk_Cartao_Usuario1_idx");

                entity.Property(e => e.CodCartao)
                    .HasColumnName("codCartao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodUsuario)
                    .HasColumnName("codUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cvv)
                    .HasColumnName("cvv")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataValidade)
                    .IsRequired()
                    .HasColumnName("dataValidade")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NomeDono)
                    .IsRequired()
                    .HasColumnName("nomeDono")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Cartao)
                    .HasForeignKey(d => d.CodUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cartao_Usuario1");
            });

            modelBuilder.Entity<ContaBancaria>(entity =>
            {
                entity.HasKey(e => e.CodConta);

                entity.ToTable("conta_bancaria", "fast_entregas");

                entity.HasIndex(e => e.CodBanco)
                    .HasName("fk_Conta_Bancaria_Banco1_idx");

                entity.HasIndex(e => e.CodUsuario)
                    .HasName("fk_ContaBancaria_Usuario_idx");

                entity.Property(e => e.CodConta)
                    .HasColumnName("codConta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Agencia)
                    .HasColumnName("agencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodBanco)
                    .HasColumnName("codBanco")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodUsuario)
                    .HasColumnName("codUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("enum('Conta Corrente','Poupança')");

                entity.HasOne(d => d.CodBancoNavigation)
                    .WithMany(p => p.ContaBancaria)
                    .HasForeignKey(d => d.CodBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Conta_Bancaria_Banco1");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.ContaBancaria)
                    .HasForeignKey(d => d.CodUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ContaBancaria_Usuario");
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.HasKey(e => e.CodEntrega);

                entity.ToTable("entrega", "fast_entregas");

                entity.HasIndex(e => e.CodUsuarioCliente)
                    .HasName("fk_Corrida_Entrega_Usuario1_idx");

                entity.HasIndex(e => e.CodUsuarioEntregador)
                    .HasName("fk_Corrida_Entrega_Usuario2_idx");

                entity.Property(e => e.CodEntrega)
                    .HasColumnName("codEntrega")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodUsuarioCliente)
                    .HasColumnName("codUsuarioCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodUsuarioEntregador)
                    .HasColumnName("codUsuarioEntregador")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Destino)
                    .IsRequired()
                    .HasColumnName("destino")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Origem)
                    .IsRequired()
                    .HasColumnName("origem")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('solicitada','cancelada','atendida','em andamento')")
                    .HasDefaultValueSql("solicitada");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.CodUsuarioClienteNavigation)
                    .WithMany(p => p.EntregaCodUsuarioClienteNavigation)
                    .HasForeignKey(d => d.CodUsuarioCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Corrida_Entrega_Usuario1");

                entity.HasOne(d => d.CodUsuarioEntregadorNavigation)
                    .WithMany(p => p.EntregaCodUsuarioEntregadorNavigation)
                    .HasForeignKey(d => d.CodUsuarioEntregador)
                    .HasConstraintName("fk_Corrida_Entrega_Usuario2");
            });

            modelBuilder.Entity<Formaspagamento>(entity =>
            {
                entity.HasKey(e => e.CodFormaPagamento);

                entity.ToTable("formaspagamento", "fast_entregas");

                entity.Property(e => e.CodFormaPagamento)
                    .HasColumnName("codFormaPagamento")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormaspagamentoHasEntrega>(entity =>
            {
                entity.HasKey(e => new { e.FormasPagamentoCodFormaPagamento, e.EntregaCodCorridaEntrega });

                entity.ToTable("formaspagamento_has_entrega", "fast_entregas");

                entity.HasIndex(e => e.EntregaCodCorridaEntrega)
                    .HasName("fk_FormasPagamento_has_Entrega_Entrega1_idx");

                entity.HasIndex(e => e.FormasPagamentoCodFormaPagamento)
                    .HasName("fk_FormasPagamento_has_Entrega_FormasPagamento1_idx");

                entity.Property(e => e.FormasPagamentoCodFormaPagamento)
                    .HasColumnName("FormasPagamento_codFormaPagamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EntregaCodCorridaEntrega)
                    .HasColumnName("Entrega_codCorrida_Entrega")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.EntregaCodCorridaEntregaNavigation)
                    .WithMany(p => p.FormaspagamentoHasEntrega)
                    .HasForeignKey(d => d.EntregaCodCorridaEntrega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FormasPagamento_has_Entrega_Entrega1");

                entity.HasOne(d => d.FormasPagamentoCodFormaPagamentoNavigation)
                    .WithMany(p => p.FormaspagamentoHasEntrega)
                    .HasForeignKey(d => d.FormasPagamentoCodFormaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FormasPagamento_has_Entrega_FormasPagamento1");
            });

            modelBuilder.Entity<SolicitacaoDeCadastro>(entity =>
            {
                entity.HasKey(e => e.CodSolicitacao);

                entity.ToTable("solicitacao_de_cadastro", "fast_entregas");

                entity.HasIndex(e => e.CodUsuarioEntregador)
                    .HasName("fk_Solicitacao_de_Cadastro_Usuario1_idx");

                entity.HasIndex(e => e.CodUsuarioFuncionario)
                    .HasName("fk_Solicitacao_de_Cadastro_Usuario2_idx");

                entity.Property(e => e.CodSolicitacao)
                    .HasColumnName("codSolicitacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodUsuarioEntregador)
                    .HasColumnName("codUsuarioEntregador")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodUsuarioFuncionario)
                    .HasColumnName("codUsuarioFuncionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("dataNascimento")
                    .HasColumnType("date");

                entity.Property(e => e.NumCnh)
                    .IsRequired()
                    .HasColumnName("numCnh")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NumRegistro)
                    .IsRequired()
                    .HasColumnName("numRegistro")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('solicitada','aprovada','reprovada','em analise')")
                    .HasDefaultValueSql("solicitada");

                entity.HasOne(d => d.CodUsuarioEntregadorNavigation)
                    .WithMany(p => p.SolicitacaoDeCadastroCodUsuarioEntregadorNavigation)
                    .HasForeignKey(d => d.CodUsuarioEntregador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Solicitacao_de_Cadastro_Usuario1");

                entity.HasOne(d => d.CodUsuarioFuncionarioNavigation)
                    .WithMany(p => p.SolicitacaoDeCadastroCodUsuarioFuncionarioNavigation)
                    .HasForeignKey(d => d.CodUsuarioFuncionario)
                    .HasConstraintName("fk_Solicitacao_de_Cadastro_Usuario2");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodUsuario);

                entity.ToTable("usuario", "fast_entregas");

                entity.Property(e => e.CodUsuario)
                    .HasColumnName("codUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StatusCliente)
                    .HasColumnName("statusCliente")
                    .HasColumnType("enum('online','offline','inativo')")
                    .HasDefaultValueSql("offline");

                entity.Property(e => e.StatusEntregador)
                    .HasColumnName("statusEntregador")
                    .HasColumnType("enum('em analise','bloqueado','online','offline')")
                    .HasDefaultValueSql("offline");
            });

            modelBuilder.Entity<UsuarioVeiculo>(entity =>
            {
                entity.HasKey(e => new { e.CodUsuario, e.CodVeiculo });

                entity.ToTable("usuario_veiculo", "fast_entregas");

                entity.HasIndex(e => e.CodUsuario)
                    .HasName("fk_Usuario_has_Veiculo_Usuario1_idx");

                entity.HasIndex(e => e.CodVeiculo)
                    .HasName("fk_Usuario_has_Veiculo_Veiculo1_idx");

                entity.Property(e => e.CodUsuario)
                    .HasColumnName("codUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodVeiculo)
                    .HasColumnName("codVeiculo")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.UsuarioVeiculo)
                    .HasForeignKey(d => d.CodUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_has_Veiculo_Usuario1");

                entity.HasOne(d => d.CodVeiculoNavigation)
                    .WithMany(p => p.UsuarioVeiculo)
                    .HasForeignKey(d => d.CodVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_has_Veiculo_Veiculo1");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.CodVeiculo);

                entity.ToTable("veiculo", "fast_entregas");

                entity.HasIndex(e => e.CodDono)
                    .HasName("fk_Veiculo_Usuario1_idx");

                entity.Property(e => e.CodVeiculo)
                    .HasColumnName("codVeiculo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ano)
                    .HasColumnName("ano")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("categoria")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodDono)
                    .HasColumnName("codDono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmUso)
                    .HasColumnName("emUso")
                    .HasColumnType("enum('Sim','Nao')");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasColumnName("placa")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Renavam)
                    .IsRequired()
                    .HasColumnName("renavam")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('disponivel','bloqueado')")
                    .HasDefaultValueSql("bloqueado");

                entity.HasOne(d => d.CodDonoNavigation)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.CodDono)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Veiculo_Usuario1");
            });
        }
    }
}
