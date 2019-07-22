using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Banco
    {
        public Banco()
        {
            ContaBancaria = new HashSet<ContaBancaria>();
        }

        public int CodBanco { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ContaBancaria> ContaBancaria { get; set; }
    }
}
