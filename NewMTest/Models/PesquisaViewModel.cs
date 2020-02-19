using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMTest.Models
{
    public class PesquisaViewModel
    {
        public string SortOrder { get; set; }
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }
        public int? PageNumber { get; set; }
    }
}
