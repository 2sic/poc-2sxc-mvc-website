using System;
using System.Collections.Generic;
using ToSic.Eav.Run;

namespace ToSic.Sxc.Mvc.Run
{
    public class MvcUser: IUser
    {
        public string IdentityToken => "mvcuser:1";
        public Guid? Guid => System.Guid.Empty;
        public List<int> Roles => new List<int>();
        public bool IsSuperUser => false;
        public bool IsDesigner => false;
    }
}
