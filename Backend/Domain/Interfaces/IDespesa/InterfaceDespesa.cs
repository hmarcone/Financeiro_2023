using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.IDespesa;

public interface InterfaceDespesa : InterfaceGeneric<Despesa>
{
    Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario);

    Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario);
}