using NewMTest.Data.Context;
using NewMTest.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMTest.Data.Repository
{
    public class PessoaRepository : DataRepository<Pessoa>, IPessoaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> GetPessoasAsync()
        {
            return await GetPessoasQuery().ToListAsync();
        }

        public  IQueryable<Pessoa> GetPessoasQuery()
        {
            return BuscarPessoa().OrderBy(c => c.Nome).AsNoTracking();
        }

        public async Task<Pessoa> GetPessoaAsync(long id)
        {
            return await BuscarPessoa().FirstOrDefaultAsync(f => f.PessoaId == id);
        }

        public async Task<List<Pessoa>> GetPessoasAsync(long[] id)
        {
            return await BuscarPessoa().Where(f => id.Contains(f.PessoaId)).ToListAsync();
        }

        private IQueryable<Pessoa> BuscarPessoa()
        {
            return _context.Pessoas;
        }
    }
}
