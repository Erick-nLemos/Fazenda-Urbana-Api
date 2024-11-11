using FazendaUrbanaApi.Data;
using FazendaUrbanaApi.Dtos.Clientes;
using FazendaUrbanaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FazendaUrbanaApi.Services.Clientes
{
    public class ClienteService : IClienteInterface
    {
        private readonly TetoVerdeContext context;
        public ClienteService(TetoVerdeContext context) {
            this.context = context;
        }

        public async Task<ResponseModel<List<Cliente>>> CriarCliente(CriacaoClienteDto criacao)
        {
            ResponseModel<List<Cliente>> resposta = new ResponseModel<List<Cliente>>();
            try
            {
                var cliente = new Cliente()
                {
                    Fantasia = criacao.Name,
                    Cnpj = criacao.Cnpj,
                    Email = criacao.Email,
                    TelCelCli = criacao.Telefone,
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

                resposta.Dados = await context.Clientes.ToListAsync();
                resposta.Mensagem = "Cliente Criado com Sucesso!";
                return resposta;
            }
            catch (DbUpdateException ex) {
                resposta.Mensagem = ex.InnerException?.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Cliente>>> EditarCliente(EdicaoClienteDto edicao)
        {
            ResponseModel<List<Cliente>> resposta = new ResponseModel<List<Cliente>>();
            try
            {
                var cliente = await context.Clientes.FirstOrDefaultAsync(clienteBanco => clienteBanco.IdCodCliente == edicao.Id);
                if (cliente == null) {
                    resposta.Mensagem = "CLiente não encontrado!";
                    return resposta;
                }
                cliente.Fantasia = edicao.Name;
                cliente.Cnpj = edicao.Cnpj;
                cliente.Email = edicao.Email;
                cliente.TelCelCli = edicao.Telefone;
                cliente.Cep = edicao.Cep;
                cliente.Rua = edicao.Rua;
                cliente.Numero = edicao.Numero;
                cliente.Bairro = edicao.Bairro;
                cliente.Cidade = edicao.Cidade;
                cliente.Uf = edicao.Uf;
                cliente.Senha = edicao.Senha;
                context.Update(cliente);
                await context.SaveChangesAsync();

                resposta.Dados = await context.Clientes.ToListAsync();
                resposta.Mensagem = "Cliente Editado com Sucesso!";
                return resposta;

            }
            catch (DbUpdateException ex) {
                resposta.Mensagem = ex.InnerException?.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Cliente>>> EditarClientePatch(int IdCliente, EdicaoParciaClientelDto edicaoDto)
        {
            ResponseModel<List<Cliente>> resposta = new ResponseModel<List<Cliente>>();
            try
            {
                var cliente = await context.Clientes.FirstOrDefaultAsync(clienteBanco => clienteBanco.IdCodCliente == IdCliente);
                if (cliente == null)
                {
                    resposta.Mensagem = "Cliente não encontrado!";
                    return resposta;
                }

                if (edicaoDto.Name != null)
                {
                    cliente.Fantasia = edicaoDto.Name;
                }
                if (edicaoDto.Cnpj != null)
                {
                    cliente.Cnpj = edicaoDto.Cnpj;
                }
                if (edicaoDto.Email != null)
                {
                    cliente.Email = edicaoDto.Email;
                }
                if (edicaoDto.Telefone != null)
                {
                    cliente.TelCelCli = edicaoDto.Telefone;
                }
                if (edicaoDto.Cep != null)
                {
                    cliente.Cep = edicaoDto.Cep;
                }
                if (edicaoDto.Rua != null)
                {
                    cliente.Rua = edicaoDto.Rua;
                }
                if (edicaoDto.Numero != null)
                {
                    cliente.Numero = edicaoDto.Numero;
                }
                if (edicaoDto.Bairro != null)
                {
                    cliente.Bairro = edicaoDto.Bairro;
                }
                if (edicaoDto.Cidade != null)
                {
                    cliente.Cidade = edicaoDto.Cidade;
                }
                if (edicaoDto.Uf != null)
                {
                    cliente.Uf = edicaoDto.Uf;
                }
                if (edicaoDto.Senha != null)
                {
                    cliente.Senha = edicaoDto.Senha;
                }

                context.Update(cliente);
                await context.SaveChangesAsync();

                resposta.Dados = await context.Clientes.ToListAsync();
                resposta.Mensagem = "Cliente Editado com Sucesso!";
                return resposta;
            }
            catch (DbUpdateException ex)
            {
                {
                    resposta.Mensagem = ex.InnerException?.Message;
                    resposta.Status = false;
                    return resposta;
                }
            }
        }

            public async Task<ResponseModel<List<Cliente>>> ExcluirCliente(int IdCliente)
            {
                ResponseModel<List<Cliente>> resposta = new ResponseModel<List<Cliente>>();
                try
                {
                    var cliente = await context.Clientes.FirstOrDefaultAsync(clienteBanco => clienteBanco.IdCodCliente == IdCliente);
                    if (cliente == null) {
                        resposta.Mensagem = "Cliente não encontrado!";
                        return resposta;
                    }
                    context.Remove(cliente);
                    await context.SaveChangesAsync();

                    resposta.Dados = await context.Clientes.ToListAsync();
                    resposta.Mensagem = "Cliente Excluido com Sucesso!";
                    return resposta;
                }
                catch (DbUpdateException ex) {
                    resposta.Mensagem = ex.InnerException?.Message;
                    resposta.Status = false;
                    return resposta;
                }
            }

            public async Task<ResponseModel<Cliente>> GetClientePorId(int IdCliente)
            {
                ResponseModel<Cliente> resposta = new ResponseModel<Cliente>();
                try
                {
                    var cliente = await this.context.Clientes.FirstOrDefaultAsync(DbCliente => DbCliente.IdCodCliente == IdCliente);
                    if (cliente == null)
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

            public async Task<ResponseModel<List<Cliente>>> ListarClientes()
            {
                ResponseModel<List<Cliente>> resposta = new ResponseModel<List<Cliente>>();
                try
                {
                    var clientes = await this.context.Clientes.ToListAsync();
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