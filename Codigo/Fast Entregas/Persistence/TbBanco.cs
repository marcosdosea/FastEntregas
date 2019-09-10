using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbBanco
    {
        public TbBanco()
        {
            TbcontaBancaria = new HashSet<TbContaBancaria>();
        }

        public int CodBanco { get; set; }
        public string Nome { get; set; }

        public ICollection<TbContaBancaria> TbcontaBancaria { get; set; }
    }
}
