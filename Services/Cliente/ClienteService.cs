using FazendaUrbanaApi.Data;
using FazendaUrbanaApi.Dtos.Cliente;
using FazendaUrbanaApi.Models;
using FazendaUrbanaApi.Models.Cliente;
using Microsoft.EntityFrameworkCore;

namespace FazendaUrbanaApi.Services.Cliente
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext context;
        public ClienteService(AppDbContext context) { 
            this.context = context;
        }
        public async Task<ResponseModel<List<ClienteModel>>> CriarCliente(CriacaoClienteDto criacao)
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
            try
            {
                var cliente = new ClienteModel()
                {
                    Name = criacao.Name,
                    Cnpj = criacao.Cnpj,
                    Email = criacao.Email,
                    Telefone = criacao.Telefone,
                    Cep = criacao.Cep,
                    Rua = criacao.Rua,
                    Numero = criacao.Numero,
                    Bairro = criacao.Bairro,
                    Cidade = criacao.Cidade,
                    Uf = criacao.Uf,
                    Senha = criacao.Senha
                };
                context.Add(cliente);
                await context.SaveChangesAsync();

                resposta.Dados = await context.Cliente.ToListAsync();
                resposta.Mensagem = "Cliente Criado com Sucesso!";
                return resposta;
            }
            catch (Exception ex) { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<ResponseModel<List<ClienteModel>>> EditarCLiente(EdicaoClienteDto edicao)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ClienteModel>>> ExcluirCLiente(int IdCliente)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<ClienteModel>> GetClientePorId(int IdCliente)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();
            try
            {
                var cliente = await this.context.Cliente.FirstOrDefaultAsync(DbCliente => DbCliente.Id == IdCliente);
                if(cliente == null)
                {
                    resposta.Mensagem = "Cliente não Encontrado!";
                    return resposta;
                }
                resposta.Dados = cliente;
                resposta.Mensagem = "Cliente Encontrado!";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ClienteModel>>> ListarClientes()
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
            try
            {
                var clientes = await this.context.Cliente.ToListAsync();
                resposta.Dados = clientes;
                resposta.Mensagem = "Clientes encontrados com Sucesso!";
                return resposta;
            }
            catch (Exception ex) { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
