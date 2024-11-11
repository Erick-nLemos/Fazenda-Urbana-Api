using System;
using System.Collections.Generic;

namespace FazendaUrbanaApi.Models;

public partial class Funcionario
{
    public int CodFunc { get; set; }

    public int? FkCodDepart { get; set; }

    public string NomeCompleto { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateOnly DataAdmissao { get; set; }

    public string Email { get; set; } = null!;

    public string Contato { get; set; } = null!;

    public string? Endereco { get; set; }

    public int Pis { get; set; }

    public string Banco { get; set; } = null!;

    public virtual Departamento? FkCodDepartNavigation { get; set; }

    public virtual ICollection<NotaFiscal> NotaFiscals { get; set; } = new List<NotaFiscal>();
}
