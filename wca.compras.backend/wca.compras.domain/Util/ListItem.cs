﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wca.compras.domain.Util
{
    public class ListItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public int? FilialId { get; set; }
    }

    public class ListItemFornecedor: ListItem
    {
        public decimal ValorFrete { get; set; }
        public decimal ValorCompraMinimoSemFrete { get; set; }
        public decimal TaxaGestaoMinimaPercentual { get; set; }
    }

}
