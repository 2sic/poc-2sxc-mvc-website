using ToSic.Eav.Logging;
using ToSic.Eav.Logging.Simple;
using ToSic.Sxc.Blocks;
using ToSic.Sxc.Mvc.Code;
using ToSic.Sxc.Mvc.Run;
using ToSic.Sxc.Mvc.TestStuff;

namespace ToSic.Sxc.Mvc.Razor
{
    public abstract partial class Page: Microsoft.AspNetCore.Mvc.RazorPages.Page, IHasLog
    {
        #region Constructor / DI
        protected Page()
        {
            Log = new Log("Mvc.Page");
        }
        public ILog Log { get; }
        #endregion

        #region DynCode 

        protected MvcDynamicCode DynCode => _dynCode ?? (_dynCode = new MvcDynamicCode(BlockBuilder, Log));
        private MvcDynamicCode _dynCode;
        #endregion

        public string Hi() => "hi";


        public IBlockBuilder BlockBuilder
        {
            get
            {
                if (_cmsBlockLoaded) return _blockBuilder;
                _cmsBlockLoaded = true;
                _blockBuilder = new BlockFromModule(
                        new MvcContainer(),
                        Log,
                        new MvcTenant(new MvcPortalSettings()))
                    .BlockBuilder as BlockBuilder;
                return _blockBuilder;
            }
        }
        private BlockBuilder _blockBuilder;
        private bool _cmsBlockLoaded;

    }
}
