using System.ComponentModel.DataAnnotations;

namespace FazendaUrbanaApi.Models.Cliente
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj {  get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero {  get; set; }
        public string Bairro {  get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Senha { get; set; }
    }
}
