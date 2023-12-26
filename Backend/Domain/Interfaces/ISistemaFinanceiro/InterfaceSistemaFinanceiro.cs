using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.ISistemaFinanceiro;

public interface InterfaceSistemaFinanceiro : InterfaceGeneric<SistemaFinanceiro>
{
    Task<IList<SistemaFinanceiro>> ListaSistemasUsuario(string emailUsuario);
    Task<bool> ExecuteCopiaDespesasSistemafinanceiro();
}