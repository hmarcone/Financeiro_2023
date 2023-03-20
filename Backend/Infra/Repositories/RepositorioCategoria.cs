using Domain.Interfaces.ICategoria;
using Entities.Entities;
using Infra.Repositories.Generics;

namespace Infra.Repositories;

public class RepositorioCategoria : RepositoryGenerics<Categoria>, InterfaceCategoria
{
    public Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario)
    {
        throw new NotImplementedException();
    }
}