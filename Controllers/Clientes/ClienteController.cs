using FazendaUrbanaApi.Dtos.Clientes;
using FazendaUrbanaApi.Models;
using FazendaUrbanaApi.Services.Clientes;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace FazendaUrbanaApi.Controllers.Clientes
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface clienteInterface;
        public ClienteController(IClienteInterface clienteInterface) { 
            this.clienteInterface = clienteInterface;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ResponseModel<Cliente>>> Login(LoginClienteDto loginClienteDto)
        {
            var clienteLogin = await this.clienteInterface.LoginValidation(loginClienteDto);
            if (!clienteLogin.loginValido)
            {
                return Unauthorized(clienteLogin.resposta.Mensagem = "Usuario ou Senha Invalidos!");
            }

            return Ok(clienteLogin.resposta.Mensagem = "Login realizado com Sucesso!");
        }

        [HttpGet("ListarClientes")]
        public async Task<ActionResult<ResponseModel<List<Cliente>>>> ListarClientes()
        {
            var clientes = await this.clienteInterface.ListarClientes();
            return Ok(clientes);
        }

        [HttpGet("ListarClientes/{IdCodCliente}")]
        public async Task<ActionResult<ResponseModel<List<Cliente>>>> GetClientePorId(int IdCodCliente)
        {
            var cliente = await this.clienteInterface.GetClientePorId(IdCodCliente);
            return Ok(cliente);
        }

        [HttpPost("CriarCliente")]
        public async Task<ActionResult<ResponseModel<Cliente>>> CriarCliente(CriacaoClienteDto criacao)
        {
            var cliente = await this.clienteInterface.CriarCliente(criacao);
            return Ok(cliente);
        }

        [HttpPut("EditarCliente")]
        public async Task<ActionResult<ResponseModel<Cliente>>> EditarCliente(EdicaoClienteDto edicao)
        {
            var cliente = await clienteInterface.EditarCliente(edicao);
            return Ok(cliente);
        }

        [HttpPatch("EditarCliente/{IdCliente}")]
        public async Task<ActionResult<ResponseModel<Cliente>>> EditarClientePatch(int IdCliente, EdicaoParciaClientelDto edicaoDto)
        {
            var cliente = await clienteInterface.EditarClientePatch(IdCliente, edicaoDto);
            return Ok(cliente);
        }

        [HttpDelete("DeletarCliente/{IdCliente}")]
        public async Task<ActionResult<ResponseModel<Cliente>>> ExcluirCliente(int IdCliente)
        {
            var cliente = await clienteInterface.ExcluirCliente(IdCliente);
            return Ok(cliente);
        }

    }
}
