using System.Collections.Generic;
using ToSic.Eav.Apps;
using ToSic.Eav.Logging;
using ToSic.Eav.Run;
using ToSic.Sxc.Mvc.TestStuff;

namespace ToSic.Sxc.Mvc.Run
{
    public class MvcZoneMapper : HasLog, IZoneMapper
    {
        /// <inheritdoc />
        public MvcZoneMapper(ILog parentLog = null) : base("DNN.ZoneMp", parentLog)
        {
        }

        public IZoneMapper Init(ILog parent)
        {
            Log.LinkTo(parent);
            return this;
        }

        public int GetZoneId(int tenantId) => tenantId;

        public int GetZoneId(ITenant tenant) => tenant.Id;

        public IAppIdentity IdentityFromTenant(int tenantId, int appId) => new AppIdentity(tenantId, appId);

        public ITenant Tenant(int zoneId) => new MvcTenant(new MvcPortalSettings());

        public List<TempTempCulture> CulturesWithState(int tenantId, int zoneId)
        {
            return new List<TempTempCulture>
            {
                new TempTempCulture("en-us", "English USA", true)
            };
        }

    }
}
