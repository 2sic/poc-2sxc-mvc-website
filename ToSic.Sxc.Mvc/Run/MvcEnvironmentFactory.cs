using System;
using ToSic.Eav.Apps;
using ToSic.Eav.Data;
using ToSic.Eav.Logging;
using ToSic.Eav.Run;
using ToSic.Eav.Security;
using IApp = ToSic.SexyContent.Interfaces.IApp;

namespace ToSic.Sxc.Mvc.Run
{
    public class MvcEnvironmentFactory : IEnvironmentFactory //, IWebFactoryTemp
    {
        /// <inheritdoc />
        public PermissionCheckBase ItemPermissions(IAppIdentity appIdentity, IEntity targetItem, ILog parentLog,
            IContainer module = null)
        {
            return new MvcPermissionCheck(parentLog);
            //=> new DnnPermissionCheck(parentLog, targetItem: targetItem, instance: module, portal: PortalSettings.Current, appIdentity: appIdentity);
        }

        /// <inheritdoc />
        public PermissionCheckBase TypePermissions(IAppIdentity appIdentity, IContentType targetType,
            IEntity targetItem, ILog parentLog, IContainer module = null)
        {
            return new MvcPermissionCheck(parentLog);
            //=> new DnnPermissionCheck(parentLog, targetType, targetItem, module, portal: PortalSettings.Current, appIdentity: appIdentity);
        }

        public PermissionCheckBase InstancePermissions(ILog parentLog, IContainer module, Eav.Apps.IApp app)
        {
            return new MvcPermissionCheck(parentLog);
            //=> new DnnPermissionCheck(parentLog, portal: PortalSettings.Current, instance: module, app: app);
        }

        /// <inheritdoc />
        public PermissionCheckBase InstancePermissions(ILog parentLog, IContainer module, IApp app)
            => throw new NotImplementedException("InstancePermissions isn't implemented yet");


        ///// <inheritdoc />
        //public DynamicCodeRoot AppAndDataHelpers(IBlockBuilder blockBuilder, ILog parentLog)
        //    => new MvcDynamicCode().Init(blockBuilder, parentLog);
    }
}
