using System;
using ToSic.Eav.Apps.Run;
using ToSic.Eav.Logging;
using ToSic.Eav.Run;

namespace ToSic.Sxc.Mvc.Run
{
    public class MvcContainer: IContainer
    {
        public MvcContainer(int tenantId = TestConstants.TenantId, int pageId = TestConstants.BlogPage,
            int id = TestConstants.BlogInstanceId, int appId = TestConstants.BlogApp, Guid? block = null)
        {
            TenantId = tenantId;
            PageId = pageId;
            Id = id;
            AppId = appId;
            Block = block ?? TestConstants.BlogGuid;
        }

        // Temp implementation, don't support im MVC
        public IContainer Init(int id, ILog parentLog) => throw new System.NotImplementedException();

        /// <inheritdoc />
        public int Id { get; }
        
        /// <inheritdoc />
        public int PageId { get; }

        /// <inheritdoc />
        public int TenantId { get; }

        /// <inheritdoc />
        public bool IsPrimary => true;

        public IBlockIdentifier BlockIdentifier
        {
            get
            {
                if (_blockIdentifier != null) return _blockIdentifier;
                return _blockIdentifier = new BlockIdentifier(TenantId, AppId, Block, Guid.Empty);
            }
        }

        private IBlockIdentifier _blockIdentifier;

        // special while testing
        public int AppId;

        public Guid Block;
    }

}
