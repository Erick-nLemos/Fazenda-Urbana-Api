using System;
using System.Collections.Generic;

namespace FazendaUrbanaApi.Models;

public partial class NotaFiscal
{
    public int CodNf { get; set; }

    public int? FkCodItem { get; set; }

    public int? FkCodFunc { get; set; }

    public DateOnly DataEmissao { get; set; }

    public int Chave { get; set; }

    public int Icms { get; set; }

    public int Ipi { get; set; }

    public int Cfop { get; set; }

    public string Situacao { get; set; } = null!;

    public virtual Funcionario? FkCodFuncNavigation { get; set; }

    public virtual ItemPedido? FkCodItemNavigation { get; set; }
}
