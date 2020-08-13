using ToSic.Eav.Run;

namespace ToSic.Sxc.Mvc.Run
{
    public class MvcContainer: IContainer
    {
        public MvcContainer(int tenantId = TestConstants.TenantId, int pageId = TestConstants.BlogPage,
            int id = TestConstants.BlogInstanceId, int appId = TestConstants.BlogApp)
        {
            TenantId = tenantId;
            PageId = pageId;
            Id = id;
            AppId = appId;
        }

        /// <inheritdoc />
        public int Id { get; }
        
        /// <inheritdoc />
        public int PageId { get; }

        /// <inheritdoc />
        public int TenantId { get; }

        /// <inheritdoc />
        public bool IsPrimary => true;

        // special while testing
        public int AppId = TestConstants.BlogApp;
    }

}
