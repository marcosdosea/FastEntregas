using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Aspnetroles
    {
        public Aspnetroles()
        {
            Aspnetroleclaims = new HashSet<Aspnetroleclaims>();
            Aspnetuserroles = new HashSet<Aspnetuserroles>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public ICollection<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public ICollection<Aspnetuserroles> Aspnetuserroles { get; set; }
    }
}
