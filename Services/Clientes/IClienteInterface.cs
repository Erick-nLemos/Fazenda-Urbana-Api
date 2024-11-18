using FazendaUrbanaApi.Dtos.Clientes;
using FazendaUrbanaApi.Models;

namespace FazendaUrbanaApi.Services.Clientes
{
    public interface IClienteInterface
    { 
        Task<ResponseModel<List<Cliente>>> ListarClientes();
        Task<ResponseModel<Cliente>> GetClientePorId(int IdCliente);
        Task<ResponseModel<Cliente>> CriarCliente(CriacaoClienteDto criacao);
        Task<ResponseModel<Cliente>> EditarCliente(int IdClinet, EdicaoClienteDto edicao);
        Task<ResponseModel<List<Cliente>>> EditarClientePatch(int IdCliente, EdicaoParciaClientelDto edicaoDto);
        Task<ResponseModel<List<Cliente>>> ExcluirCliente(int IdCliente);

    }
}
