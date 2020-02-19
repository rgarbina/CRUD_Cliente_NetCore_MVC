using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMTest.Entity
{
    public class ModeloBase
    {
        protected ModeloBase()
        {
            DataInclusao = DateTime.Now;
            DataEdicao = DateTime.Now;
        }

        public DateTime? DataInclusao { get; set; }
        public DateTime DataEdicao { get; set; }
    }
}
