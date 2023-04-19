using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.ICategoria
{
    public interface InterfaceCategoria : InterfaceGeneric<Categoria>
    {
        Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario);
    }
}