namespace ToSic.Sxc.Mvc.TestStuff
{
    public class MvcPortalSettings
    {
        public string DefaultLanguage => TestConstants.DefaultLanguage;
        public int Id => TestConstants.TenantId;

        public string Name => "Fake MVC Tenant Name";

        public string HomePath => "todo/";
    }
}
