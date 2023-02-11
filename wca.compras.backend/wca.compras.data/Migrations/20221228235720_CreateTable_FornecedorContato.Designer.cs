﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wca.compras.data.DataAccess;

#nullable disable

namespace wca.compras.data.Migrations
{
    [DbContext(typeof(WcaContext))]
    [Migration("20221228235720_CreateTable_FornecedorContato")]
    partial class CreateTable_FornecedorContato
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClienteUsuario", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ClienteUsuario");
                });

            modelBuilder.Entity("PerfilPermissao", b =>
                {
                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.Property<int>("PermissaoId")
                        .HasColumnType("int");

                    b.HasKey("PerfilId", "PermissaoId");

                    b.HasIndex("PermissaoId");

                    b.ToTable("PerfilPermissao");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.HasIndex("FilialId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.ClienteContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AprovaPedido")
                        .HasColumnType("bit")
                        .HasColumnName("aprova_pedido");

                    b.Property<string>("Celular")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("celular");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("ClienteContatos");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.ClienteOrcamentoConfiguracao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("AprovadoPor")
                        .HasColumnType("tinyint")
                        .HasColumnName("aprovador_por");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<int>("QuantidadeMes")
                        .HasColumnType("int")
                        .HasColumnName("quantidade_mes");

                    b.Property<int>("TipoFornecimentoId")
                        .HasColumnType("int")
                        .HasColumnName("tipofornecimento_id");

                    b.Property<int>("Tolerancia")
                        .HasColumnType("int")
                        .HasColumnName("tolerancia");

                    b.Property<decimal>("ValorPedido")
                        .HasColumnType("money")
                        .HasColumnName("valor_pedido");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoFornecimentoId");

                    b.ToTable("ClienteOrcamentoConfiguracaos");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Filial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("wca.compras.domain.Entities.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.HasIndex("FilialId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.FornecedorContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AprovaPedido")
                        .HasColumnType("bit")
                        .HasColumnName("aprova_pedido");

                    b.Property<string>("Celular")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("celular");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<int?>("FornecedorId")
                        .HasColumnType("int")
                        .HasColumnName("fornecedor_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("FornecedorContatos");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Permissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome");

                    b.Property<string>("Regra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("regra");

                    b.HasKey("Id");

                    b.ToTable("Permissao");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("codigo");

                    b.Property<int?>("FornecedorId")
                        .HasColumnType("int")
                        .HasColumnName("fornecedor_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("nome");

                    b.Property<decimal>("TaxaGestao")
                        .HasColumnType("money")
                        .HasColumnName("taxa_gestao");

                    b.Property<int>("TipoFornecimentoId")
                        .HasColumnType("int")
                        .HasColumnName("tipofornecimento_id");

                    b.Property<string>("UnidadeMedida")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("unidade_medida");

                    b.Property<decimal>("Valor")
                        .HasColumnType("money")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("TipoFornecimentoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Requisicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_criacao");

                    b.Property<byte>("Destino")
                        .HasColumnType("tinyint")
                        .HasColumnName("destino");

                    b.Property<int?>("FilialId")
                        .HasColumnType("int")
                        .HasColumnName("filial_id");

                    b.Property<int?>("FornecedorId")
                        .HasColumnType("int")
                        .HasColumnName("fornecedor_id");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint")
                        .HasColumnName("status");

                    b.Property<decimal>("TaxaGestao")
                        .HasColumnType("money")
                        .HasColumnName("taxa_gestao");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("money")
                        .HasColumnName("valor_total");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FilialId");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Requisicoes");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.RequisicaoHistorico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_hora");

                    b.Property<string>("Evento")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("evento");

                    b.Property<int>("RequisicaoId")
                        .HasColumnType("int")
                        .HasColumnName("requisicao_id");

                    b.HasKey("Id");

                    b.HasIndex("RequisicaoId");

                    b.ToTable("RequisicaoHistoricos");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.RequisicaoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("codigo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("nome");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("quantidade");

                    b.Property<int>("RequisicaoId")
                        .HasColumnType("int")
                        .HasColumnName("requisicao_id");

                    b.Property<decimal>("TaxaGestao")
                        .HasColumnType("money")
                        .HasColumnName("taxa_gestao");

                    b.Property<int>("TipoFornecimentoId")
                        .HasColumnType("int")
                        .HasColumnName("tipofornecimento_id");

                    b.Property<string>("UnidadeMedida")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("unidade_medida");

                    b.Property<decimal>("Valor")
                        .HasColumnType("money")
                        .HasColumnName("valor");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("money")
                        .HasColumnName("valor_total");

                    b.HasKey("Id");

                    b.HasIndex("RequisicaoId");

                    b.HasIndex("TipoFornecimentoId");

                    b.ToTable("RequisicaoItens");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.ResetPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_criacao");

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_expiracao");

                    b.Property<DateTime?>("DataRevogacao")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("data_revogacao");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("token");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ResetPassword");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.TipoFornecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("TipoFornecimento");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<int?>("FilialId")
                        .HasColumnType("int")
                        .HasColumnName("filial_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("password");

                    b.Property<int?>("PerfilId")
                        .HasColumnType("int")
                        .HasColumnName("perfil_id");

                    b.HasKey("Id");

                    b.HasIndex("FilialId");

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ClienteUsuario", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Cliente", null)
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.compras.domain.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PerfilPermissao", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Perfil", null)
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.compras.domain.Entities.Permissao", null)
                        .WithMany()
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Cliente", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("FilialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filial");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.ClienteContato", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Cliente", "Cliente")
                        .WithMany("ClienteContatos")
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.ClienteOrcamentoConfiguracao", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Cliente", "Cliente")
                        .WithMany("ClienteOrcamentoConfiguracao")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.compras.domain.Entities.TipoFornecimento", "TipoFornecimento")
                        .WithMany()
                        .HasForeignKey("TipoFornecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TipoFornecimento");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Fornecedor", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("FilialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filial");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.FornecedorContato", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany("FornecedorContatos")
                        .HasForeignKey("FornecedorId");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Produto", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId");

                    b.HasOne("wca.compras.domain.Entities.TipoFornecimento", "TipoFornecimento")
                        .WithMany()
                        .HasForeignKey("TipoFornecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("TipoFornecimento");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Requisicao", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("wca.compras.domain.Entities.Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("FilialId");

                    b.HasOne("wca.compras.domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId");

                    b.HasOne("wca.compras.domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Cliente");

                    b.Navigation("Filial");

                    b.Navigation("Fornecedor");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.RequisicaoHistorico", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Requisicao", null)
                        .WithMany("RequisicaoHistorico")
                        .HasForeignKey("RequisicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wca.compras.domain.Entities.RequisicaoItem", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Requisicao", null)
                        .WithMany("RequisicaoItens")
                        .HasForeignKey("RequisicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wca.compras.domain.Entities.TipoFornecimento", "TipoFornecimento")
                        .WithMany()
                        .HasForeignKey("TipoFornecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoFornecimento");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.ResetPassword", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Usuario", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Usuario", b =>
                {
                    b.HasOne("wca.compras.domain.Entities.Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("FilialId");

                    b.HasOne("wca.compras.domain.Entities.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId");

                    b.Navigation("Filial");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Cliente", b =>
                {
                    b.Navigation("ClienteContatos");

                    b.Navigation("ClienteOrcamentoConfiguracao");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Fornecedor", b =>
                {
                    b.Navigation("FornecedorContatos");

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("wca.compras.domain.Entities.Requisicao", b =>
                {
                    b.Navigation("RequisicaoHistorico");

                    b.Navigation("RequisicaoItens");
                });
#pragma warning restore 612, 618
        }
    }
}
