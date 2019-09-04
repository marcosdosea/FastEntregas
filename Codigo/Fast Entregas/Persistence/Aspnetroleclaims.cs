using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Aspnetroleclaims
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public Aspnetroles Role { get; set; }
    }
}
