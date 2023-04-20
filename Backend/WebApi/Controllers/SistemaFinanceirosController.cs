using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class SistemaFinanceirosController : ControllerBase
{
    private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;
    private readonly ISistemaFinanceiroServico _iSistemaFinanceiroServico;

    public SistemaFinanceirosController(InterfaceSistemaFinanceiro InterfaceSistemaFinanceiro,
        ISistemaFinanceiroServico ISistemaFinanceiroServico)
    {
        _interfaceSistemaFinanceiro = InterfaceSistemaFinanceiro;
        _iSistemaFinanceiroServico = ISistemaFinanceiroServico;
    }

    [HttpGet("/api/ListaSistemasUsuario")]
    [Produces("application/json")]
    public async Task<object> ListaSistemasUsuario(string emailUsuario)
    {
        return await _interfaceSistemaFinanceiro.ListaSistemasUsuario(emailUsuario);
    }

    [HttpPost("/api/AdicionarSistemaFinanceiro")]
    [Produces("application/json")]
    public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
    {
        await _iSistemaFinanceiroServico.AdicionarSistemaFinanceiro(sistemaFinanceiro);

        return Task.FromResult(sistemaFinanceiro);
    }

    [HttpPut("/api/AtualizarSistemaFinanceiro")]
    [Produces("application/json")]
    public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
    {
        await _iSistemaFinanceiroServico.AtualizarSistemaFinanceiro(sistemaFinanceiro);

        return Task.FromResult(sistemaFinanceiro);
    }

    [HttpGet("/api/ObterSistemaFinanceiro")]
    [Produces("application/json")]
    public async Task<object> ObterSistemaFinanceiro(int id)
    {
        return await _interfaceSistemaFinanceiro.GetEntityById(id);
    }


    [HttpDelete("/api/DeleteSistemaFinanceiro")]
    [Produces("application/json")]
    public async Task<object> DeleteSistemaFinanceiro(int id)
    {
        try
        {
            var sistemaFinanceiro = await _interfaceSistemaFinanceiro.GetEntityById(id);

            await _interfaceSistemaFinanceiro.Delete(sistemaFinanceiro);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }
}
