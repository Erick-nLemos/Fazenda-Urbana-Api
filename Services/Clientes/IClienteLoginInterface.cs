using FazendaUrbanaApi.Dtos.Clientes;
using FazendaUrbanaApi.Models;

namespace FazendaUrbanaApi.Services.Clientes
{
    public interface IClienteLoginInterface
    {
        Task<(bool loginValido, ResponseModel<Cliente> resposta)> LoginValidation(LoginClienteDto loginClienteDto);
    }
}
