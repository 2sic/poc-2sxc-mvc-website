using System;
using System.Collections.Generic;
using System.Text;
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

        public int GetZoneId(int tenantId) => 2;

        public int GetZoneId(ITenant tenant) => 2;

        public IAppIdentity IdentityFromTenant(int tenantId, int appId)
        {
            throw new NotImplementedException();
        }

        public ITenant Tenant(int zoneId) => new MvcTenant(new MvcPortalSettings());

        public List<TempTempCulture> CulturesWithState(int tenantId, int zoneId)
        {
            return new List<TempTempCulture>()
            {
                new TempTempCulture("en-us", "English USA", true)
            };
        }
    }
}
