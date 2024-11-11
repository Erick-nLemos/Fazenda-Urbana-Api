using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FazendaUrbanaApi.Models;

public class Cliente
{
    [Key]
    public int IdCodCliente { get; set; }

    public string Fantasia { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? TelCelCli { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Rua { get; set; }

    public int? Numero { get; set; }

    public string Uf { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string Senha { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<PedidoVendum> PedidoVenda { get; set; } = new List<PedidoVendum>();
}
