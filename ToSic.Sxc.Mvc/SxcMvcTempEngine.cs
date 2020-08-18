using System;
using Microsoft.AspNetCore.Html;
using ToSic.Eav.Apps.Run;
using ToSic.Eav.Logging;
using ToSic.Sxc.Blocks;
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
            var context = new InstanceContext(
                new MvcTenant(new MvcPortalSettings(zoneId)),
                new MvcPage(pageId, null),
                new MvcContainer(zoneId, pageId: pageId, id: containerId, appId: appId, block: blockGuid),
                new MvcUser()
            );

            var block = new BlockFromModule().Init(context, Log);
            var blockBuilder = block.BlockBuilder;
            return blockBuilder.Render();
        }
    }
}
