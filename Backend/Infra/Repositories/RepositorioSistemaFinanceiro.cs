using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entities;
using Infra.Repositories.Generics;

namespace Infra.Repositories;

public class RepositorioSistemaFinanceiro : RepositoryGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
{
    public Task<IList<SistemaFinanceiro>> ListaSistemasUsuario(string emailUsuario)
    {
        throw new NotImplementedException();
    }
}