namespace ToSic.Sxc.Mvc.TestStuff
{
    public class MvcPortalSettings
    {
        public MvcPortalSettings(int zoneId = TestConstants.TenantId)
        {
            Id = zoneId;
        }

        public string DefaultLanguage => TestConstants.DefaultLanguage;
        public int Id { get; }

        public string Name => "Fake MVC Tenant Name";

        public string HomePath => "wwwroot/";
    }
}
