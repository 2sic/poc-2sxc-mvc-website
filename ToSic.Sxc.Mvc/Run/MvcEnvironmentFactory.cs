using System;
using ToSic.Eav.Apps;
using ToSic.Eav.Apps.Environment;
using ToSic.Eav.Data;
using ToSic.Eav.Logging;
using ToSic.Eav.Repositories;
using ToSic.Eav.Run;
using ToSic.Eav.Security;
using ToSic.SexyContent.Interfaces;
using ToSic.Sxc.Code;
using IApp = ToSic.SexyContent.Interfaces.IApp;

namespace ToSic.Sxc.Mvc.Run
{
    public class MvcEnvironmentFactory : IEnvironmentFactory, IWebFactoryTemp
    {
        /// <inheritdoc />
        public PermissionCheckBase ItemPermissions(IAppIdentity appIdentity, IEntity targetItem, ILog parentLog, IContainer module = null)
            => throw new NotImplementedException();
            //=> new DnnPermissionCheck(parentLog, targetItem: targetItem, instance: module, portal: PortalSettings.Current, appIdentity: appIdentity);

        /// <inheritdoc />
        public PermissionCheckBase TypePermissions(IAppIdentity appIdentity, IContentType targetType, IEntity targetItem, ILog parentLog, IContainer module = null)
            => throw new NotImplementedException();
        //=> new DnnPermissionCheck(parentLog, targetType, targetItem, module, portal: PortalSettings.Current, appIdentity: appIdentity);

        public PermissionCheckBase InstancePermissions(ILog parentLog, IContainer module, Eav.Apps.IApp app)
        {
            throw new NotImplementedException();
            //=> new DnnPermissionCheck(parentLog, portal: PortalSettings.Current, instance: module, app: app);
        }

        /// <inheritdoc />
        public PermissionCheckBase InstancePermissions(ILog parentLog, IContainer module, IApp app)
            => throw new NotImplementedException();

        ///// <inheritdoc />
        //public IPagePublishing PagePublisher(ILog parentLog) => new NoPagePublishig();

        ///// <inheritdoc />
        //public IAppEnvironment Environment(ILog parentLog) => new MvcEnvironment(parentLog);

        /// <inheritdoc />
        public DynamicCodeRoot AppAndDataHelpers(Blocks.IBlockBuilder blockBuilder)
            => throw new NotImplementedException();
            //=> new DnnDynamicCode(blockBuilder, 9);


        //// experimental
        //public IAppFileSystemLoader AppFileSystemLoader(int appId, string path, ILog log)
        //    => throw new NotImplementedException();
        //    //=> new DnnAppFileSystemLoader(appId, path, PortalSettings.Current, log);

        //// experimental
        ///// <summary>
        ///// This is the simpler signature, which is used from Eav.Core
        ///// The more advance signature which can also deliver InputTypes is the AppFileSystemLoader
        ///// </summary>
        ///// <param name="appId"></param>
        ///// <param name="path"></param>
        ///// <param name="log"></param>
        ///// <returns></returns>
        //public IAppRepositoryLoader AppRepositoryLoader(int appId, string path, ILog log) => AppFileSystemLoader(appId, path, log);
    }
}
