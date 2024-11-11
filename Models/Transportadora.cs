using System;
using System.Collections.Generic;

namespace FazendaUrbanaApi.Models;

public partial class Transportadora
{
    public int CodTrans { get; set; }

    public string RazaoSocial { get; set; } = null!;

    public string Fantasia { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Contato { get; set; }

    public string Endereco { get; set; } = null!;

    public virtual ICollection<PedidoVendum> PedidoVenda { get; set; } = new List<PedidoVendum>();
}
