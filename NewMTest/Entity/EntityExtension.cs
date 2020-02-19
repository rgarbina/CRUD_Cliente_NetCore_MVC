using NewMTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMTest.Entity
{
    public static class EntityExtension
    {
        public static PessoaViewModel ToModel(this Pessoa pessoa)
        {
            return new PessoaViewModel
            {
                PessoaId = pessoa.PessoaId,
                Ativado = pessoa.Ativado,
                Nome = pessoa.Nome,
                DataNascimento = pessoa.DataNascimento,
                Celular = pessoa.Celular,
                Email = pessoa.Email,
                Cpf = pessoa.Cpf,
                Endereco = pessoa.Endereco,
                Observacao = pessoa.Observacao
            };
        }

        public static List<PessoaViewModel> ToListModel(this List<Pessoa> listaPessoa)
        {
            return listaPessoa.Select(pessoa => pessoa.ToModel()).ToList();
        }

        public static IQueryable<PessoaViewModel> ToListModel(this IQueryable<Pessoa> query)
        {
            var pagedList = query.Select(pessoa => pessoa.ToModel()).AsQueryable();
            return pagedList;
        }
    }
}
