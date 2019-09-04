using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Aspnetuserroles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public Aspnetroles Role { get; set; }
        public Aspnetusers User { get; set; }
    }
}
