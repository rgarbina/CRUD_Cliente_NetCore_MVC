using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMTest.Models
{
    public class PesquisaPessoaViewModel
    {
        public PesquisaViewModel Pesquisa { get; set; }
        public IEnumerable<PessoaViewModel> Lista { get; set; }
    }
}
