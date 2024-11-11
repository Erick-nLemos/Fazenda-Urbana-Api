using System;
using System.Collections.Generic;

namespace FazendaUrbanaApi.Models;

public partial class Estoque
{
    public int CodDeposito { get; set; }

    public int? FkCodProduto { get; set; }

    public int Saldo { get; set; }

    public string? Apartamento { get; set; }

    public string? Movimentacao { get; set; }

    public virtual Produto? FkCodProdutoNavigation { get; set; }
}
