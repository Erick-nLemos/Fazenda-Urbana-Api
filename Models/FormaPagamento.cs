using System;
using System.Collections.Generic;

namespace FazendaUrbanaApi.Models;

public partial class FormaPagamento
{
    public int CodPagto { get; set; }

    public string? Pix { get; set; }

    public string? Boleto { get; set; }

    public string? Deposito { get; set; }

    public string? Cheque { get; set; }

    public decimal? Dinheiro { get; set; }

    public virtual ICollection<PedidoVendum> PedidoVenda { get; set; } = new List<PedidoVendum>();
}
