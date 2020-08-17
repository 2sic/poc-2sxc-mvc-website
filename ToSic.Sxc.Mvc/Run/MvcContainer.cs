using System;
using System.Collections.Generic;
using ToSic.Eav.Apps.Run;
using ToSic.Eav.Logging;
using ToSic.Eav.Run;
using ToSic.Sxc.Web;

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
        public bool IsPrimary => BlockIdentifier.AppId == TestConstants.PrimaryApp;

        public List<KeyValuePair<string, string>> Parameters
        {
            get => _parameters ??
                   (_parameters = Eav.Factory.Resolve<IHttp>().QueryStringKeyValuePairs());
            set => _parameters = value;
        }
        private List<KeyValuePair<string, string>> _parameters;

        public IBlockIdentifier BlockIdentifier 
            => _blockIdentifier ?? (_blockIdentifier = new BlockIdentifier(TenantId, AppId, Block, Guid.Empty));

        private IBlockIdentifier _blockIdentifier;

        // special while testing
        public int AppId;

        public Guid Block;
    }

}
