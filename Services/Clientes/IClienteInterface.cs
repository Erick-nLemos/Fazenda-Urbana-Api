using FazendaUrbanaApi.Dtos.Clientes;
using FazendaUrbanaApi.Models;

namespace FazendaUrbanaApi.Services.Clientes
{
    public interface IClienteInterface
    { 
        Task<ResponseModel<List<Cliente>>> ListarClientes();
        Task<ResponseModel<Cliente>> GetClientePorId(int IdCliente);
        Task<ResponseModel<List<Cliente>>> CriarCliente(CriacaoClienteDto criacao);
        Task<ResponseModel<List<Cliente>>> EditarCliente(EdicaoClienteDto edicao);
        Task<ResponseModel<List<Cliente>>> EditarClientePatch(int IdCLiente, EdicaoParciaClientelDto edicaoDto);
        Task<ResponseModel<List<Cliente>>> ExcluirCliente(int IdCliente);

    }
}
