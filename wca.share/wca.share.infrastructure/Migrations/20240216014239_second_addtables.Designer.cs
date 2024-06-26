﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wca.share.infrastruture.Context;

#nullable disable

namespace wca.share.infrastructure.Migrations
{
    [DbContext(typeof(WcaContext))]
    [Migration("20240216014239_second_addtables")]
    partial class second_addtables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("wca.share.domain.Entities.Assunto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Assuntos");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("cnpj");

                    b.Property<string>("Cep")
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("cidade");

                    b.Property<string>("Endereco")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("endereco");

                    b.Property<int>("FilialId")
                        .HasColumnType("int")
                        .HasColumnName("filial_id");

                    b.Property<string>("InscricaoEstadual")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("inscricao_estadual");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<string>("Numero")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("numero");

                    b.Property<string>("UF")
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("uf");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoGI")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("codigo_gi");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("wca.share.domain.Entities.ItemMudanca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descricao");

                    b.Property<int?>("SolicitacaoMudancaBaseSolicitacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SolicitacaoMudancaBaseSolicitacaoId");

                    b.ToTable("ItensMudanca");
                });

            modelBuilder.Entity("wca.share.domain.Entities.MotivoDemissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("motivo");

                    b.HasKey("Id");

                    b.ToTable("MotivosDemissao");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Notificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_hora");

                    b.Property<string>("Entidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("entidade");

                    b.Property<int>("EntidadeId")
                        .HasColumnType("int")
                        .HasColumnName("entidade_id");

                    b.Property<bool>("Lido")
                        .HasColumnType("bit")
                        .HasColumnName("lido");

                    b.Property<string>("Nota")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("nota");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.ToTable("Notificacoes");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Solicitacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<DateTime>("DataSolicitacao")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_solicitacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descricao");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int")
                        .HasColumnName("funcionario_id");

                    b.Property<int>("GestorId")
                        .HasColumnType("int")
                        .HasColumnName("gestor_id");

                    b.Property<int?>("ResponsavelId")
                        .HasColumnType("int")
                        .HasColumnName("responsavel_id");

                    b.Property<int>("SolicitacaoTipoId")
                        .HasColumnType("int")
                        .HasColumnName("soliticacaotipo_id");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("GestorId");

                    b.HasIndex("ResponsavelId");

                    b.HasIndex("SolicitacaoTipoId");

                    b.ToTable("Solicitacoes");
                });

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoComunicado", b =>
                {
                    b.Property<int>("SolicitacaoId")
                        .HasColumnType("int")
                        .HasColumnName("solicitacao_id");

                    b.Property<int>("AssuntoId")
                        .HasColumnType("int")
                        .HasColumnName("assunto_id");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_alteracao");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("observacao");

                    b.HasKey("SolicitacaoId");

                    b.HasIndex("AssuntoId");

                    b.ToTable("SolicitacaoComunicado");
                });

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoDesligamento", b =>
                {
                    b.Property<int>("SolicitacaoId")
                        .HasColumnType("int")
                        .HasColumnName("solicitacao_id");

                    b.Property<DateTime?>("DataCredito")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_credito");

                    b.Property<DateTime?>("DataDemissao")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_demissao");

                    b.Property<int>("MotivoDemissaoId")
                        .HasColumnType("int")
                        .HasColumnName("motivodemissao_id");

                    b.Property<int>("StatusApontamento")
                        .HasColumnType("int")
                        .HasColumnName("status_apontamento");

                    b.Property<int>("StatusAvisoPrevio")
                        .HasColumnType("int")
                        .HasColumnName("status_aviso_previo");

                    b.Property<int>("StatusExameDemissional")
                        .HasColumnType("int")
                        .HasColumnName("status_exame_demissional");

                    b.Property<int>("StatusHomologacaoSindicato")
                        .HasColumnType("int")
                        .HasColumnName("status_homologacao_sindicato");

                    b.Property<bool>("TemContratoExperiencia")
                        .HasColumnType("bit")
                        .HasColumnName("tem_contrato_experiencia");

                    b.HasKey("SolicitacaoId");

                    b.HasIndex("MotivoDemissaoId");

                    b.ToTable("SolicitacaoDesligamento");
                });

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoMudancaBase", b =>
                {
                    b.Property<int>("SolicitacaoId")
                        .HasColumnType("int")
                        .HasColumnName("solicitacao_id");

                    b.Property<int?>("ClienteDestinoId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_destino_id");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_alteracao");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("observacao");

                    b.HasKey("SolicitacaoId");

                    b.HasIndex("ClienteDestinoId");

                    b.ToTable("SolicitacaoMudancaBase");
                });

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.ToTable("SolicitacaoTipo");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("wca.share.domain.Entities.UsuarioClientes", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.HasKey("UsuarioId", "ClienteId");

                    b.HasIndex("ClienteId");

                    b.ToTable("UsuarioClientes");
                });

            modelBuilder.Entity("wca.share.domain.Entities.ItemMudanca", b =>
                {
                    b.HasOne("wca.share.domain.Entities.SolicitacaoMudancaBase", null)
                        .WithMany("ItensMudanca")
                        .HasForeignKey("SolicitacaoMudancaBaseSolicitacaoId");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Solicitacao", b =>
                {
                    b.HasOne("wca.share.domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.share.domain.Entities.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.share.domain.Entities.Usuario", "Gestor")
                        .WithMany()
                        .HasForeignKey("GestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.share.domain.Entities.Funcionario", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId");

                    b.HasOne("wca.share.domain.Entities.SolicitacaoTipo", "SolicitacaoTipo")
                        .WithMany()
                        .HasForeignKey("SolicitacaoTipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Gestor");

                    b.Navigation("Responsavel");

                    b.Navigation("SolicitacaoTipo");
                });

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoComunicado", b =>
                {
                    b.HasOne("wca.share.domain.Entities.Assunto", "Assunto")
                        .WithMany()
                        .HasForeignKey("AssuntoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.share.domain.Entities.Solicitacao", "Solicitacao")
                        .WithOne("Comunicado")
                        .HasForeignKey("wca.share.domain.Entities.SolicitacaoComunicado", "SolicitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assunto");

                    b.Navigation("Solicitacao");
                });

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoDesligamento", b =>
                {
                    b.HasOne("wca.share.domain.Entities.MotivoDemissao", "Motivo")
                        .WithMany()
                        .HasForeignKey("MotivoDemissaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.share.domain.Entities.Solicitacao", "Solicitacao")
                        .WithOne("Desligamento")
                        .HasForeignKey("wca.share.domain.Entities.SolicitacaoDesligamento", "SolicitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motivo");

                    b.Navigation("Solicitacao");
                });

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoMudancaBase", b =>
                {
                    b.HasOne("wca.share.domain.Entities.Cliente", "ClienteDestino")
                        .WithMany()
                        .HasForeignKey("ClienteDestinoId");

                    b.HasOne("wca.share.domain.Entities.Solicitacao", "Solicitacao")
                        .WithOne("MudancaBase")
                        .HasForeignKey("wca.share.domain.Entities.SolicitacaoMudancaBase", "SolicitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClienteDestino");

                    b.Navigation("Solicitacao");
                });

            modelBuilder.Entity("wca.share.domain.Entities.UsuarioClientes", b =>
                {
                    b.HasOne("wca.share.domain.Entities.Cliente", "Cliente")
                        .WithMany("UsuarioClientes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.share.domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Cliente", b =>
                {
                    b.Navigation("UsuarioClientes");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Solicitacao", b =>
                {
                    b.Navigation("Comunicado");

                    b.Navigation("Desligamento");

                    b.Navigation("MudancaBase");
                });

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoMudancaBase", b =>
                {
                    b.Navigation("ItensMudanca");
                });
#pragma warning restore 612, 618
        }
    }
}
