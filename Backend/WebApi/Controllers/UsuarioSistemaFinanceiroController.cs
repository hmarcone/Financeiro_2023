﻿using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class UsuarioSistemaFinanceiroController : ControllerBase
{

    private readonly InterfaceUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
    private readonly IUsuarioSistemaFinanceiroServico _iUsuarioSistemaFinanceiroServico;

    public UsuarioSistemaFinanceiroController(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro, IUsuarioSistemaFinanceiroServico iUsuarioSistemaFinanceiroServico)
    {
        _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
        _iUsuarioSistemaFinanceiroServico = iUsuarioSistemaFinanceiroServico;
    }

    [HttpGet("/api/v1/ListarUsuariosSistema")]
    [Produces("application/json")]
    public async Task<object> ListaSistemasUsuario(int idSistema)
    {
        return await _interfaceUsuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
    }

    [HttpPost("/api/v1/CadastrarUsuarioNoSistema")]
    [Produces("application/json")]
    public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
    {
        try
        {
            await _iUsuarioSistemaFinanceiroServico.CadastrarUsuarioNoSistema(
               new UsuarioSistemaFinanceiro
               {
                   IdSistema = idSistema,
                   EmailUsuario = emailUsuario,
                   Administrador = false,
                   SistemaAtual = true
               });
        }
        catch (Exception)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(true);

    }

    [HttpDelete("/api/v1/DeleteUsuarioSistemaFinanceiro")]
    [Produces("application/json")]
    public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
    {
        try
        {
            var usuarioSistemaFinanceiro = await _interfaceUsuarioSistemaFinanceiro.GetEntityById(id);

            await _interfaceUsuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
        }
        catch (Exception)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(true);

    }
}
