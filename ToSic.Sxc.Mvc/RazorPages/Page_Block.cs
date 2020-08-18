using ToSic.Eav.Apps.Run;
using ToSic.Sxc.Blocks;
using ToSic.Sxc.Mvc.Code;
using ToSic.Sxc.Mvc.Run;
using ToSic.Sxc.Mvc.TestStuff;

namespace ToSic.Sxc.Mvc.RazorPages
{
    public partial class Page
    {
        #region DynCode 

        protected MvcDynamicCode DynCode => _dynCode ?? (_dynCode = new MvcDynamicCode().Init(BlockBuilder, Log));
        private MvcDynamicCode _dynCode;
        #endregion
        public IBlockBuilder BlockBuilder
        {
            get
            {
                if (_blockLoaded) return _blockBuilder;
                _blockLoaded = true;
                var context = new InstanceContext(
                    new MvcTenant(new MvcPortalSettings()),
                    new MvcPage(0, null), 
                    new MvcContainer(),
                    new MvcUser()
                );
                _blockBuilder = new BlockFromModule().Init(context, Log).BlockBuilder as BlockBuilder;
                return _blockBuilder;
            }
        }
        private BlockBuilder _blockBuilder;
        private bool _blockLoaded;

    }
}
