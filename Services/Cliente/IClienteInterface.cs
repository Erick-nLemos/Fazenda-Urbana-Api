using FazendaUrbanaApi.Dtos.Cliente;
using FazendaUrbanaApi.Models;
using FazendaUrbanaApi.Models.Cliente;

namespace FazendaUrbanaApi.Services.Cliente
{
    public interface IClienteInterface
    {
        Task<ResponseModel<List<ClienteModel>>> ListarClientes();
        Task<ResponseModel<ClienteModel>> GetClientePorId(int IdCliente);
        Task<ResponseModel<List<ClienteModel>>> CriarCliente(CriacaoClienteDto criacao);
        Task<ResponseModel<List<ClienteModel>>> EditarCLiente(EdicaoClienteDto edicao);
        Task<ResponseModel<List<ClienteModel>>> ExcluirCLiente(int IdCliente);

    }
}
