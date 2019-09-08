using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Aspnetuserlogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public Aspnetusers User { get; set; }
    }
}
