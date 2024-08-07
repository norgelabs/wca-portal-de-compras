﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using wca.compras.domain.Interfaces;

namespace wca.compras.domain.Entities
{
    public class Fornecedor : IEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        [Column("nome", TypeName = "varchar(150)")]
        public string Nome { get; set; }

        [Required, MaxLength(20)]
        [Column("cnpj", TypeName = "varchar(20)")]
        public string CNPJ { get; set; }

        [MaxLength(20)]
        [Column("inscricao_estadual", TypeName = "varchar(20)")]
        public string? InscricaoEstadual { get; set; }

        [MaxLength(150)]
        [Column("endereco", TypeName = "varchar(150)")]
        public string? Endereco { get; set; }

        [MaxLength(9)]
        [Column("cep", TypeName = "varchar(9)")]
        public string? Cep { get; set; }

        [MaxLength(10)]
        [Column("numero", TypeName = "varchar(10)")]
        public string? Numero { get; set; }

        [MaxLength(100)]
        [Column("cidade", TypeName = "varchar(100)")]
        public string? Cidade { get; set; }

        [MaxLength(2)]
        [Column("uf", TypeName = "varchar(2)")]
        public string? UF { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; } = true;

        [JsonIgnore]
        public Filial Filial { get; set; }

        [Column("filial_id")]
        public int FilialId { get; set; }

        [Column("valor_frete", TypeName = "money")]
        public decimal ValorFrete {  get; set; } = decimal.Zero;

        [Column("valor_compra_minimo_sem_frete", TypeName = "money")]
        public decimal ValorCompraMinimoSemFrete { get; set; } = decimal.Zero;

        [Column("taxa_gestao_minima_percentual", TypeName = "decimal(4,2)")]
        public decimal TaxaGestaoMinimaPercentual { get; set; } = decimal.Zero;

        public IList<Produto> Produtos { get; set; } = new List<Produto>();

        public IList<FornecedorContato> FornecedorContatos { get; set; } = new List<FornecedorContato>();
    }
}
