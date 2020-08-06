using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToSic.Eav.Run;

namespace Website.Plumbing
{
    public class MvcEnvironment : IEnvironment
    {
        public string DefaultLanguage => "en";
        public IUser User => null;
    }
}
