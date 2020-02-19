using NewMTest.Entity;
using NewMTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMTest.Services
{
    public interface IPessoaServices
    {
        Task<List<PessoaViewModel>> GetPessoasAsync();
        Task<PessoaViewModel> GetPessoaAsync(long id);
        IQueryable<Pessoa> GetPessoasQuery();
        Task<PessoaViewModel> InsertPessoaAsync(PessoaViewModel pessoa);
        Task<bool> UpdatePessoaAsync(PessoaViewModel pessoa);
        Task<bool> DeletePessoaAsync(long id);
        Task<bool> DeletePessosAsync(long[] id);
    }
}
