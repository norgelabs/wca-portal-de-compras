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
    [Migration("20240404171038_CreateTable_UsuarioCentrodeCusto")]
    partial class CreateTable_UsuarioCentrodeCusto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ItemMudancaSolicitacaoMudancaBase", b =>
                {
                    b.Property<int>("ItensMudancaId")
                        .HasColumnType("int");

                    b.Property<int>("SolicitacaoMudancaBaseSolicitacaoId")
                        .HasColumnType("int");

                    b.HasKey("ItensMudancaId", "SolicitacaoMudancaBaseSolicitacaoId");

                    b.HasIndex("SolicitacaoMudancaBaseSolicitacaoId");

                    b.ToTable("ItemMudancaSolicitacaoMudancaBase");
                });

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

            modelBuilder.Entity("wca.share.domain.Entities.CentroCusto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<int>("Codigo")
                        .HasColumnType("int")
                        .HasColumnName("codigo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("CentrosDeCusto");
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

                    b.Property<int?>("CodigoCliente")
                        .HasColumnType("int")
                        .HasColumnName("codigo_cliente");

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

            modelBuilder.Entity("wca.share.domain.Entities.Configuracao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Chave")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("chave");

                    b.Property<string>("ComboValores")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("varchar(8000)")
                        .HasColumnName("combo_valores");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("descricao");

                    b.Property<int>("TipoCampo")
                        .HasMaxLength(500)
                        .HasColumnType("int")
                        .HasColumnName("tipo_campo");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.ToTable("Configuracoes");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Filial", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Filiais");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CentroCustoId")
                        .HasColumnType("int")
                        .HasColumnName("centrocusto_id");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<int?>("CodigoFuncionario")
                        .HasColumnType("int")
                        .HasColumnName("codigo_funcionario");

                    b.Property<int?>("DDDCelular")
                        .HasColumnType("int")
                        .HasColumnName("ddd_celular");

                    b.Property<DateTime?>("DataAdmissao")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_admissao");

                    b.Property<DateTime?>("DataDemissao")
                        .HasColumnType("datetime2")
                        .HasColumnName("data_demissao");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("nome");

                    b.Property<int?>("NumeroCelular")
                        .HasColumnType("int")
                        .HasColumnName("numero_celular");

                    b.Property<string>("NumeroPis")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("numero_pis");

                    b.HasKey("Id");

                    b.HasIndex("CentroCustoId");

                    b.HasIndex("ClienteId");

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

                    b.HasKey("Id");

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

                    b.Property<int?>("CentroCustoId")
                        .HasColumnType("int")
                        .HasColumnName("centrocusto_id");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<DateTime>("DataSolicitacao")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_solicitacao");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descricao");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int")
                        .HasColumnName("funcionario_id");

                    b.Property<int?>("ResponsavelId")
                        .HasColumnType("int")
                        .HasColumnName("responsavel_id");

                    b.Property<int>("SolicitacaoTipoId")
                        .HasColumnType("int")
                        .HasColumnName("soliticacaotipo_id");

                    b.Property<int>("StatusSolicitacaoId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.HasKey("Id");

                    b.HasIndex("CentroCustoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("ResponsavelId");

                    b.HasIndex("SolicitacaoTipoId");

                    b.HasIndex("StatusSolicitacaoId");

                    b.ToTable("Solicitacoes");
                });

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoArquivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CaminhoArquivo")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("caminho_arquivo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("descricao");

                    b.Property<int>("SolicitacaoId")
                        .HasColumnType("int")
                        .HasColumnName("solicitacao_id");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.HasIndex("SolicitacaoId");

                    b.ToTable("SolicitacaoArquivos");
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

                    b.Property<int?>("StatusApontamento")
                        .HasColumnType("int")
                        .HasColumnName("status_apontamento");

                    b.Property<int?>("StatusAvisoPrevio")
                        .HasColumnType("int")
                        .HasColumnName("status_aviso_previo");

                    b.Property<int?>("StatusBeneficio")
                        .HasColumnType("int")
                        .HasColumnName("status_beneficio");

                    b.Property<int?>("StatusExameDemissional")
                        .HasColumnType("int")
                        .HasColumnName("status_exame_demissional");

                    b.Property<int?>("StatusFichaEpi")
                        .HasColumnType("int")
                        .HasColumnName("status_ficha_epi");

                    b.Property<int?>("StatusReembolso")
                        .HasColumnType("int")
                        .HasColumnName("status_reembolso");

                    b.Property<bool>("TemContratoExperiencia")
                        .HasColumnType("bit")
                        .HasColumnName("tem_contrato_experiencia");

                    b.HasKey("SolicitacaoId");

                    b.HasIndex("MotivoDemissaoId");

                    b.ToTable("SolicitacaoDesligamento");
                });

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoHistorico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_hora");

                    b.Property<string>("Evento")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("evento");

                    b.Property<int>("SolicitacaoId")
                        .HasColumnType("int")
                        .HasColumnName("solicitacao_id");

                    b.HasKey("Id");

                    b.HasIndex("SolicitacaoId");

                    b.ToTable("SolicitacaoHistorico");
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

            modelBuilder.Entity("wca.share.domain.Entities.StatusSolicitacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Autorizar")
                        .HasColumnType("bit")
                        .HasColumnName("autorizar");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("color");

                    b.Property<int>("Notifica")
                        .HasColumnType("int")
                        .HasColumnName("notifica");

                    b.Property<int?>("ProximoStatusId")
                        .HasColumnType("int")
                        .HasColumnName("proximo_status_id")
                        .HasComment("Utilizado quando campo autorizar = 1, após aprovação mudará para o status indicado aqui");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("status");

                    b.Property<string>("StatusIntermediario")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("status_intermediario");

                    b.Property<string>("TemplateNotificacao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("template_notificacao");

                    b.HasKey("Id");

                    b.ToTable("StatusSolicitacao");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Celular")
                        .HasColumnType("varchar(30)")
                        .HasColumnName("celular");

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

            modelBuilder.Entity("wca.share.domain.Entities.UsuarioCentrodeCustos", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("CentroCustoId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "CentroCustoId");

                    b.HasIndex("CentroCustoId");

                    b.ToTable("UsuarioCentrodeCustos");
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

            modelBuilder.Entity("wca.share.domain.Entities.UsuarioConfiguracoes", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    b.Property<bool>("NotificarPorChatBot")
                        .HasColumnType("bit")
                        .HasColumnName("notificar_por_chatbot");

                    b.Property<bool>("NotificarPorEmail")
                        .HasColumnType("bit")
                        .HasColumnName("notificar_por_email");

                    b.HasKey("UsuarioId");

                    b.ToTable("UsuarioConfiguracoes");
                });

            modelBuilder.Entity("ItemMudancaSolicitacaoMudancaBase", b =>
                {
                    b.HasOne("wca.share.domain.Entities.ItemMudanca", null)
                        .WithMany()
                        .HasForeignKey("ItensMudancaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.share.domain.Entities.SolicitacaoMudancaBase", null)
                        .WithMany()
                        .HasForeignKey("SolicitacaoMudancaBaseSolicitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wca.share.domain.Entities.CentroCusto", b =>
                {
                    b.HasOne("wca.share.domain.Entities.Cliente", "Cliente")
                        .WithMany("CentroCusto")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Funcionario", b =>
                {
                    b.HasOne("wca.share.domain.Entities.CentroCusto", "CentroCusto")
                        .WithMany()
                        .HasForeignKey("CentroCustoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.share.domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CentroCusto");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Solicitacao", b =>
                {
                    b.HasOne("wca.share.domain.Entities.CentroCusto", "CentroCusto")
                        .WithMany()
                        .HasForeignKey("CentroCustoId");

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

                    b.HasOne("wca.share.domain.Entities.Usuario", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId");

                    b.HasOne("wca.share.domain.Entities.SolicitacaoTipo", "SolicitacaoTipo")
                        .WithMany()
                        .HasForeignKey("SolicitacaoTipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.share.domain.Entities.StatusSolicitacao", "StatusSolicitacao")
                        .WithMany()
                        .HasForeignKey("StatusSolicitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CentroCusto");

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Responsavel");

                    b.Navigation("SolicitacaoTipo");

                    b.Navigation("StatusSolicitacao");
                });

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoArquivo", b =>
                {
                    b.HasOne("wca.share.domain.Entities.Solicitacao", "Solicitacao")
                        .WithMany("Anexos")
                        .HasForeignKey("SolicitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solicitacao");
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

            modelBuilder.Entity("wca.share.domain.Entities.SolicitacaoHistorico", b =>
                {
                    b.HasOne("wca.share.domain.Entities.Solicitacao", null)
                        .WithMany("Historico")
                        .HasForeignKey("SolicitacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("wca.share.domain.Entities.UsuarioCentrodeCustos", b =>
                {
                    b.HasOne("wca.share.domain.Entities.CentroCusto", "CentroCusto")
                        .WithMany("UsuarioCentrodeCustos")
                        .HasForeignKey("CentroCustoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.share.domain.Entities.Usuario", "Usuario")
                        .WithMany("UsuarioCentrodeCustos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CentroCusto");

                    b.Navigation("Usuario");
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

            modelBuilder.Entity("wca.share.domain.Entities.UsuarioConfiguracoes", b =>
                {
                    b.HasOne("wca.share.domain.Entities.Usuario", "Usuario")
                        .WithOne("UsuarioConfiguracoes")
                        .HasForeignKey("wca.share.domain.Entities.UsuarioConfiguracoes", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("wca.share.domain.Entities.CentroCusto", b =>
                {
                    b.Navigation("UsuarioCentrodeCustos");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Cliente", b =>
                {
                    b.Navigation("CentroCusto");

                    b.Navigation("UsuarioClientes");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Solicitacao", b =>
                {
                    b.Navigation("Anexos");

                    b.Navigation("Comunicado");

                    b.Navigation("Desligamento");

                    b.Navigation("Historico");

                    b.Navigation("MudancaBase");
                });

            modelBuilder.Entity("wca.share.domain.Entities.Usuario", b =>
                {
                    b.Navigation("UsuarioCentrodeCustos");

                    b.Navigation("UsuarioConfiguracoes");
                });
#pragma warning restore 612, 618
        }
    }
}
