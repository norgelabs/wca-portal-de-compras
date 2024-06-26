﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using wca.compras.domain.Interfaces;
using System.Text.Json.Serialization;

namespace wca.compras.domain.Entities
{
    public class TipoFornecimento: IEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        [Column("nome", TypeName = "varchar(150)")]
        public string Nome { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; } = true;

        [JsonIgnore]
        public IList<Usuario> Usuario { get; set; } = new List<Usuario>();
    }
}
