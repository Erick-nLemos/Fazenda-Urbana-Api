using System;
using System.Collections.Generic;

namespace FazendaUrbanaApi.Models;

public partial class Valore
{
    public int IdValor { get; set; }

    public string NomeTabela { get; set; } = null!;

    public DateOnly DataCadastro { get; set; }

    public decimal ValorReal { get; set; }
}
