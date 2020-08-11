using ToSic.Eav.Run;

namespace ToSic.Sxc.Mvc.Run
{
    public class MvcContainer: IContainer
    {
        public MvcContainer() { }

        /// <inheritdoc />
        public int Id => TestConstants.InstanceId; 

        /// <inheritdoc />
        public int PageId => TestConstants.PageId;

        /// <inheritdoc />
        public int TenantId => TestConstants.TenantId;

        /// <inheritdoc />
        public bool IsPrimary => true;
    }

}
