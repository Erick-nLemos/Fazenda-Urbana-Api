using System;
using System.Collections.Generic;

namespace FazendaUrbanaApi.Models;

public partial class Produto
{
    public int CodProduto { get; set; }

    public string? Status { get; set; }

    public int Ncm { get; set; }

    public DateOnly? DataCadastro { get; set; }

    public int? CodigoBarra { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();
}
