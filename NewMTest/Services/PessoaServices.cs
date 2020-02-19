using NewMTest.Data.Repository;
using NewMTest.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewMTest.Models;
using Microsoft.EntityFrameworkCore;

namespace NewMTest.Services
{
    public class PessoaServices : IPessoaServices
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger _logger;

        public PessoaServices(IPessoaRepository pessoaRepository, ILoggerFactory loggerFactory)
        {
            _pessoaRepository = pessoaRepository;
            _logger = loggerFactory.CreateLogger("PessoaServices");
        }

        public async Task<List<PessoaViewModel>> GetPessoasAsync()
        {
            return (await _pessoaRepository.GetPessoasQuery().Take(10).ToListAsync()).ToListModel();
        }

        public IQueryable<Pessoa> GetPessoasQuery()
        {
            return _pessoaRepository.GetPessoasQuery();
        }

        public async Task<PessoaViewModel> GetPessoaAsync(long id)
        {
            return (await _pessoaRepository.GetPessoaAsync(id)).ToModel();
        }

        public async Task<PessoaViewModel> InsertPessoaAsync(PessoaViewModel pessoa)
        {
            var oPessoa = new Pessoa
            {
                Nome = pessoa.Nome,
                DataNascimento = pessoa.DataNascimento.GetValueOrDefault(),
                Endereco = pessoa.Endereco,
                Celular = pessoa.Celular,
                Email = pessoa.Email,
                Cpf = pessoa.Cpf,
                Observacao = pessoa.Observacao
            };

            _pessoaRepository.Add(oPessoa);
            try
            {
                await _pessoaRepository.SaveChangesAsync();

                pessoa = (await _pessoaRepository.GetPessoaAsync(oPessoa.PessoaId)).ToModel();
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(InsertPessoaAsync)}: " + exp.Message);
            }

            return pessoa;
        }

        public async Task<bool> UpdatePessoaAsync(PessoaViewModel pessoa)
        {
            var oPessoa = await _pessoaRepository.GetPessoaAsync(pessoa.PessoaId);

            oPessoa.Nome = pessoa.Nome;
            oPessoa.DataNascimento = pessoa.DataNascimento.GetValueOrDefault();
            oPessoa.Endereco = pessoa.Endereco;
            oPessoa.Celular = pessoa.Celular;
            oPessoa.Email = pessoa.Email;
            oPessoa.Cpf = pessoa.Cpf;
            oPessoa.Observacao = pessoa.Observacao;

            _pessoaRepository.Update(oPessoa);
            try
            {
                return (await _pessoaRepository.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _logger.LogError($"Error in {nameof(UpdatePessoaAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> DeletePessoaAsync(long id)
        {
            var oPessoa = await _pessoaRepository.GetPessoaAsync(id);
            _pessoaRepository.Delete(oPessoa);
            try
            {
                return (await _pessoaRepository.SaveChangesAsync() > 0 ? true : false);
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(DeletePessoaAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> DeletePessosAsync(long[] id)
        {
            var listaPessoa = await _pessoaRepository.GetPessoasAsync(id);
            _pessoaRepository.DeleteList(listaPessoa);
            try
            {
                return (await _pessoaRepository.SaveChangesAsync() > 0 ? true : false);
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(DeletePessoaAsync)}: " + exp.Message);
            }
            return false;
        }

    }
}
