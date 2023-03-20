using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entities;
using Infra.Repositories.Generics;

namespace Infra.Repositories;

public class RepositorioUsuarioSistemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
{
    public Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int IdSistema)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
    {
        throw new NotImplementedException();
    }

    public Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
    {
        throw new NotImplementedException();
    }
}