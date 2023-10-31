using Domain.Interfaces.IDespesa;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class RepositorioDespesa : RepositoryGenerics<Despesa>, InterfaceDespesa
{
    private readonly DbContextOptions<ContextBase> _OptionsBuilder;

    public RepositorioDespesa()
    {
        _OptionsBuilder = new DbContextOptions<ContextBase>();
    }

    public async Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
    {
        using (var banco = new ContextBase(_OptionsBuilder))
        {
            //return await
            //   (from s in banco.SistemaFinanceiro
            //    join c in banco.Categoria on s.Id equals c.IdSistema
            //    join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
            //    join d in banco.Despesa on c.Id equals d.IdCategoria
            //    where us.EmailUsuario.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano
            //    select d).AsNoTracking().ToListAsync();

            var despesas = await banco.SistemaFinanceiro
                       .Join(banco.Categoria, s => s.Id, c => c.IdSistema, (s, c) => new { s, c })
                       .Join(banco.UsuarioSistemaFinanceiro, sc => sc.s.Id, us => us.IdSistema, (sc, us) => new { sc, us })
                       .Join(banco.Despesa, scus => scus.sc.c.Id, d => d.IdCategoria, (scus, d) => new { scus, d })
                       .Where(x => x.scus.us.EmailUsuario.Equals(emailUsuario) && x.scus.sc.s.Mes == x.d.Mes && x.scus.sc.s.Ano == x.d.Ano)
                       .Select(x => x.d)
                       .AsNoTracking()
                       .ToListAsync();

            return despesas;
        }
    }

    public async Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
    {
        using (var banco = new ContextBase(_OptionsBuilder))
        {
            return await
               (from s in banco.SistemaFinanceiro
                join c in banco.Categoria on s.Id equals c.IdSistema
                join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                join d in banco.Despesa on c.Id equals d.IdCategoria
                where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && !d.Pago
                select d).AsNoTracking().ToListAsync();
        }
    }
}