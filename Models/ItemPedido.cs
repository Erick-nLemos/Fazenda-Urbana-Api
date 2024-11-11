using System;
using System.Collections.Generic;

namespace FazendaUrbanaApi.Models;

public partial class ItemPedido
{
    public int CodItem { get; set; }

    public int? FkCodProduto { get; set; }

    public int CodPedido { get; set; }

    public int Quantidade { get; set; }

    public string? Status { get; set; }

    public virtual Produto? FkCodProdutoNavigation { get; set; }

    public virtual ICollection<NotaFiscal> NotaFiscals { get; set; } = new List<NotaFiscal>();
}
