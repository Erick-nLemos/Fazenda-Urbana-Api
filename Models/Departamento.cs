using System;
using System.Collections.Generic;

namespace FazendaUrbanaApi.Models;

public partial class Departamento
{
    public int CodDepart { get; set; }

    public string Descr { get; set; } = null!;

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}
