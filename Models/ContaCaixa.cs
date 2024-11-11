using System;
using System.Collections.Generic;

namespace FazendaUrbanaApi.Models;

public partial class ContaCaixa
{
    public int CodCaixa { get; set; }

    public string? EntradaCaixa { get; set; }

    public string? SaidaCaixa { get; set; }

    public DateOnly? DataMovimentacao { get; set; }

    public string? SaldoCaixa { get; set; }
}
