using FazendaUrbanaApi.Data;
using FazendaUrbanaApi.Dtos.Clientes;
using FazendaUrbanaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FazendaUrbanaApi.Services.Clientes
{
    
    public class LoginClienteService : IClienteLoginInterface
    {
        private readonly TetoVerdeContext context;

        public LoginClienteService(TetoVerdeContext context) { 
            this.context = context;
        }

        public async Task<(bool loginValido, ResponseModel<Cliente> resposta)> LoginValidation(LoginClienteDto loginClienteDto)
        {
            ResponseModel<Cliente> resposta = new ResponseModel<Cliente>();
            bool loginValido = false;
            try
            {
                var cliente = await context.Clientes.FirstOrDefaultAsync(clienteBanco => clienteBanco.Fantasia == loginClienteDto.Name);
                if (cliente == null)
                {
                    resposta.Mensagem = "Usuario ou Senha Invalidos.";
                    return (loginValido, resposta);
                }

                if (cliente.Senha.Equals(loginClienteDto.Senha))
                {
                    resposta.Dados = cliente;
                    resposta.Mensagem = "Login encontrado!";
                    loginValido = true;
                    return (loginValido, resposta);
                }
                else
                {
                    resposta.Mensagem = "Usuario ou Senha Invalidos.";
                }

                return (loginValido, resposta);
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return (loginValido, resposta);
            }
        }
    }
}
