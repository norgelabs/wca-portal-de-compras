﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wca.reembolso.infrastruture.Context;

#nullable disable

namespace wca.reembolso.infrastruture.Migrations
{
    [DbContext(typeof(WcaReembolsoContext))]
    partial class WcaReembolsoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("wca.reembolso.domain.Entities.Cliente", b =>
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

                    b.Property<decimal>("ValorLimite")
                        .HasColumnType("money")
                        .HasColumnName("valor_limite");

                    b.HasKey("Id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("wca.reembolso.domain.Entities.TipoDespesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("tipo");

                    b.Property<decimal>("Valor")
                        .HasColumnType("money")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.ToTable("TiposDespesa");
                });

            modelBuilder.Entity("wca.reembolso.domain.Entities.UsuarioClientes", b =>
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

            modelBuilder.Entity("wca.reembolso.domain.Entities.UsuarioClientes", b =>
                {
                    b.HasOne("wca.reembolso.domain.Entities.Cliente", "Cliente")
                        .WithMany("UsuarioClientes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("wca.reembolso.domain.Entities.Cliente", b =>
                {
                    b.Navigation("UsuarioClientes");
                });
#pragma warning restore 612, 618
        }
    }
}
