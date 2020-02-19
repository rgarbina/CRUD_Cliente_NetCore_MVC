using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMTest.Entity
{
    public class Pessoa : ModeloBase
    {
        public Pessoa()
        {
            Ativado = true;
        }

        public long PessoaId { get; set; }
        public bool Ativado { get; set; }
        public string Nome { get; set; }    
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Observacao { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

    }
}
