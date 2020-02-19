using NewMTest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMTest.Data.Repository
{
    public interface IPessoaRepository : IDataRepository<Pessoa>, IDisposable
    {
        Task<List<Pessoa>> GetPessoasAsync();
        IQueryable<Pessoa> GetPessoasQuery();
        Task<Pessoa> GetPessoaAsync(long id);
        Task<List<Pessoa>> GetPessoasAsync(long[] id);
    }
}
