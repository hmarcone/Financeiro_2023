﻿using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class RepositorioSistemaFinanceiro : RepositoryGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
{
    private readonly DbContextOptions<ContextBase> _OptionsBuilder;

    public RepositorioSistemaFinanceiro()
    {
        _OptionsBuilder = new DbContextOptions<ContextBase>();
    }

    public async Task<IList<SistemaFinanceiro>> ListaSistemasUsuario(string emailUsuario)
    {
        using (var banco = new ContextBase(_OptionsBuilder))
        {
            return await
               (from s in banco.SistemaFinanceiro
                join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                where us.EmailUsuario.Equals(emailUsuario)
                select s).AsNoTracking().ToListAsync();
        }
    }
}