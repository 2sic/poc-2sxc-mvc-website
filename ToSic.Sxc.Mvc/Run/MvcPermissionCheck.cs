﻿using System.Collections.Generic;
using ToSic.Eav.Apps.Security;
using ToSic.Eav.Run;
using ToSic.Eav.Security;

namespace ToSic.Sxc.Mvc.Run
{
    public class MvcPermissionCheck: AppPermissionCheck
    {
        public MvcPermissionCheck(): base("Mvc.PrmChk") { }

        protected override bool EnvironmentAllows(List<Grants> grants) => false;

        protected override bool VerifyConditionOfEnvironment(string condition) => false;

        protected override IUser User => new MvcUser();
    }
}
