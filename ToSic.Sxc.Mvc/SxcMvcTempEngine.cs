using System;
using Microsoft.AspNetCore.Html;
using ToSic.Eav.Apps.Run;
using ToSic.Eav.Logging;
using ToSic.Sxc.Blocks;
using ToSic.Sxc.Code;
using ToSic.Sxc.Mvc.Code;
using ToSic.Sxc.Mvc.Run;
using ToSic.Sxc.Mvc.TestStuff;

namespace ToSic.Sxc.Mvc
{
    public class SxcMvcTempEngine: HasLog
    {
        // Empty constructor for DI for now
        public SxcMvcTempEngine() : base("Mvc.View") { }

        public string Test() => "hello test from " + nameof(SxcMvcTempEngine);

        public HtmlString Render(int zoneId, int pageId, int containerId, int appId, Guid blockGuid)
        {
            var blockBuilder = CreateBuilder(zoneId, pageId, containerId, appId, blockGuid, Log);
            return blockBuilder.Render();
        }

        public static DynamicCodeRoot CreateDynCode(int zoneId, int pageId, int containerId, int appId, Guid blockGuid,
            ILog log) =>
            new MvcDynamicCode().Init(CreateBuilder(zoneId, pageId, containerId, appId, blockGuid, log), log);

        public static IBlockBuilder CreateBuilder(int zoneId, int pageId, int containerId, int appId, Guid blockGuid, ILog log)
        {
            var context = CreateContext(zoneId, pageId, containerId, appId, blockGuid);
            var block = new BlockFromModule().Init(context, log);
            return block.BlockBuilder;
        }

        public static InstanceContext CreateContext(int zoneId, int pageId, int containerId, int appId, Guid blockGuid)
            => new InstanceContext(
                new MvcTenant(new MvcPortalSettings(zoneId)),
                new MvcPage(pageId, null),
                new MvcContainer(zoneId, pageId: pageId, id: containerId, appId: appId, block: blockGuid),
                new MvcUser()
            );
    }
}
