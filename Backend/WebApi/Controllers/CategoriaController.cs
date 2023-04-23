using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly InterfaceCategoria _interfaceCategoria;
        private readonly ICategoriaServico _iCategoriaServico;

        public CategoriaController(InterfaceCategoria interfaceCategoria, ICategoriaServico iCategoriaServico)
        {
            _interfaceCategoria = interfaceCategoria;
            _iCategoriaServico = iCategoriaServico;
        }

        [HttpGet("/api/v1/ListarCategoriasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriasUsuario(string emailUsuario)
        {
            return await _interfaceCategoria.ListarCategoriasUsuario(emailUsuario);
        }

        [HttpPost("/api/v1/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoria(Categoria categoria)
        {
            await _iCategoriaServico.AdicionarCategoria(categoria);

            return categoria;
        }

        [HttpPut("/api/v1/AtualizarCategoria")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoria(Categoria categoria)
        {
            await _iCategoriaServico.AtualizarCategoria(categoria);

            return categoria;
        }

        [HttpGet("/api/v1/ObterCategoria")]
        [Produces("application/json")]
        public async Task<object> ObterCategoria(int id)
        {
            return await _interfaceCategoria.GetEntityById(id);
        }

        [HttpDelete("/api/v1/DeleteCategoria")]
        [Produces("application/json")]
        public async Task<object> DeleteCategoria(int id)
        {
            try
            {
                var categoria = await _interfaceCategoria.GetEntityById(id);
                await _interfaceCategoria.Delete(categoria);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
