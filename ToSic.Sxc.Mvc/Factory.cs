using System;
using ToSic.Eav.Documentation;
using ToSic.Eav.Logging;
using ToSic.Eav.Logging.Simple;
using ToSic.Eav.LookUp;
using ToSic.Eav.Run;
using ToSic.Sxc.Apps;
using ToSic.Sxc.LookUp;

namespace ToSic.Sxc.Mvc
{
    public class Factory
    {
        [InternalApi_DoNotUse_MayChangeWithoutNotice]
        public static IApp App(
            int zoneId,
            int appId,
            ITenant tenant,
            bool publishingEnabled,
            bool showDrafts,
            ILog parentLog)
        {
            var log = new Log("Dnn.Factry", parentLog);
            log.Add($"Create App(z:{zoneId}, a:{appId}, tenantObj:{tenant != null}, publishingEnabled: {publishingEnabled}, showDrafts: {showDrafts}, parentLog: {parentLog != null})");
            var appStuff = new App(tenant, zoneId, appId,
                ConfigurationProvider.Build(showDrafts, publishingEnabled, new LookUpEngine(parentLog)),
                true, parentLog);
            return appStuff;
        }
    }
}
