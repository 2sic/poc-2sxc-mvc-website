using System.Collections.Generic;
using ToSic.Eav.Data;
using ToSic.Eav.Logging;
using ToSic.Eav.Run;
using ToSic.Eav.Security;
using PermissionCheckBase = ToSic.Eav.Security.PermissionCheckBase;

namespace ToSic.Sxc.Mvc.Run
{
    public class MvcPermissionCheck: PermissionCheckBase
    {
        public MvcPermissionCheck(ILog parentLog, IContentType targetType = null, IEntity targetItem = null, IEnumerable<Permission> permissions1 = null, IEnumerable<Permission> permissions2 = null) : base(parentLog, targetType, targetItem, permissions1, permissions2)
        {
        }

        protected override bool EnvironmentAllows(List<Grants> grants) => false;

        protected override bool VerifyConditionOfEnvironment(string condition) => false;

        protected override IUser User { get; }
    }
}
