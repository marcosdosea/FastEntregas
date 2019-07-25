using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbBanco
    {
        public TbBanco()
        {
            ContaBancaria = new HashSet<TbContaBancaria>();
        }

        public int CodBanco { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<TbContaBancaria> ContaBancaria { get; set; }
    }
}
