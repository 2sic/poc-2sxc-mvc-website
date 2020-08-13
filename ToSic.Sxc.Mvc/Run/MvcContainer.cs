using ToSic.Eav.Run;

namespace ToSic.Sxc.Mvc.Run
{
    public class MvcContainer: IContainer
    {
        public MvcContainer(int tenantId = TestConstants.TenantId, int pageId = TestConstants.PageId,
            int id = TestConstants.InstanceId)
        {
            TenantId = tenantId;
            PageId = pageId;
            Id = id;
        }

        /// <inheritdoc />
        public int Id { get; }
        
        /// <inheritdoc />
        public int PageId { get; }

        /// <inheritdoc />
        public int TenantId { get; }

        /// <inheritdoc />
        public bool IsPrimary => true;
    }

}
