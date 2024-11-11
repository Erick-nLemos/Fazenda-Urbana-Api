using System;
using System.Collections.Generic;

namespace FazendaUrbanaApi.Models;

public partial class PedidoVendum
{
    public int CodPedido { get; set; }

    public DateOnly DataCompra { get; set; }

    public decimal? ValorFrete { get; set; }

    public string? TipoFrete { get; set; }

    public int? FkIdCodCliente { get; set; }

    public int? FkCodTrans { get; set; }

    public int? FkCodPagto { get; set; }

    public virtual FormaPagamento? FkCodPagtoNavigation { get; set; }

    public virtual Transportadora? FkCodTransNavigation { get; set; }

    public virtual Cliente? FkIdCodClienteNavigation { get; set; }
}
