using Domain.Interfaces.IDespesa;
using Entities.Entities;
using Infra.Repositories.Generics;

namespace Infra.Repositories;

public class RepositorioDespesa : RepositoryGenerics<Despesa>, InterfaceDespesa
{
    public Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
    {
        throw new NotImplementedException();
    }
}