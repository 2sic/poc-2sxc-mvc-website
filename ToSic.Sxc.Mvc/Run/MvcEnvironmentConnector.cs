﻿using System;
using ToSic.Eav.Data;
using ToSic.Eav.Logging;
using ToSic.Eav.Run;
using ToSic.Sxc.Apps;
using ToSic.Sxc.Apps.Blocks;
using ToSic.Sxc.Blocks;
using ToSic.Sxc.Run;

namespace ToSic.Sxc.Mvc.Run
{
    internal class MvcEnvironmentConnector: IEnvironmentConnector
    {
        public int? GetAppIdFromInstance(IContainer instance, int zoneId)
        {
            return TestConstants.AppId;
        }

        public void SetAppIdForInstance(IContainer instance, IAppEnvironment env, int? appId, ILog parentLog) => throw new NotImplementedException();

        public void SetPreviewTemplate(int instanceId, Guid previewTemplateGuid) => throw new NotImplementedException();

        public void SetContentGroup(int instanceId, bool wasCreated, Guid guid) => throw new NotImplementedException();

        public BlockConfiguration GetInstanceContentGroup(BlocksRuntime cgm, ILog log, int instanceId, int? pageId)
        {
            var wrapLog = log.Call<BlockConfiguration>($"find content-group for mid#{instanceId} and page#{pageId}");
            //var mci = ModuleController.Instance;
            //var tabId = pageId ?? mci.GetTabModulesByModule(instanceId)[0].TabID;
            //var settings = mci.GetModule(instanceId, tabId, false).ModuleSettings;

            //var maybeGuid = null as string; // settings[Settings.ContentGroupGuidString];
            //Guid.TryParse(maybeGuid?.ToString(), out var groupGuid);
            var previewTemplateString = null as string; // settings[Settings.PreviewTemplateIdString]?.ToString();
            var templateGuid = !string.IsNullOrEmpty(previewTemplateString)
                ? Guid.Parse(previewTemplateString)
                : new Guid();

            var groupGuid = TestConstants.InstanceContentBlockDb[instanceId];

            var found = cgm.GetContentGroupOrGeneratePreview(groupGuid, templateGuid);
            return wrapLog("ok", found);
        }

        public void UpdateTitle(IBlockBuilder blockBuilder, IEntity titleItem) => throw new NotImplementedException();
    }
}
