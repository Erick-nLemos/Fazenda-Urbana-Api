using FazendaUrbanaApi.Dtos.Cliente;
using FazendaUrbanaApi.Models;
using FazendaUrbanaApi.Models.Cliente;
using FazendaUrbanaApi.Services.Cliente;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace FazendaUrbanaApi.Controllers.Cliente
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface clienteInterface;
        public ClienteController(IClienteInterface clienteInterface) { 
            this.clienteInterface = clienteInterface;
        }

        [HttpGet("ListaClientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClientes()
        {
            var clientes = await this.clienteInterface.ListarClientes();
            return Ok(clientes);
        }

        [HttpPost("CriarCliente")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> CriarCliente(CriacaoClienteDto criacao)
        {
            var cliente = await this.clienteInterface.CriarCliente(criacao);
            return Ok(cliente);
        }

    }
}
