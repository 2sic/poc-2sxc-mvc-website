using ToSic.Sxc.Blocks;
using ToSic.Sxc.Code;
using ToSic.Sxc.Mvc.Code;

namespace ToSic.Sxc.Mvc.RazorPages
{
    public partial class SxcRazorPage<TModel>: IIsSxcRazorPage
    {
        #region DynCode 

        public DynamicCodeRoot DynCode
        {
            get => _dynCode ?? (_dynCode = new MvcDynamicCode().Init(BlockBuilder, Log));
            set => _dynCode = value;
        }

        private DynamicCodeRoot _dynCode;
        #endregion

        public IBlockBuilder BlockBuilder
        {
            get
            {
                if (_blockLoaded) return _blockBuilder;
                _blockLoaded = true;
                //var context = new InstanceContext(
                //    new MvcTenant(new MvcPortalSettings()),
                //    new MvcPage(PageId, null),
                //    new MvcContainer(id: Id, pageId: PageId, appId: AppId, block: Block),
                //    new MvcUser()
                //);
                //_blockBuilder = new BlockFromModule().Init(context, Log).BlockBuilder as BlockBuilder;
                _blockBuilder = SxcMvcTempEngine.CreateBuilder(TestConstants.TenantId, PageId, Id, AppId, Block, Log);
                return _blockBuilder;
            }
        }
        private IBlockBuilder _blockBuilder;
        private bool _blockLoaded;

    }
}
