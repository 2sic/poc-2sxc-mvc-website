using ToSic.Eav.Logging;
using ToSic.Eav.Logging.Simple;
using ToSic.Sxc.Blocks;
using ToSic.Sxc.Mvc.Run;
using ToSic.Sxc.Mvc.TestStuff;

namespace ToSic.Sxc.Mvc.Razor
{
    public abstract class Page: Microsoft.AspNetCore.Mvc.RazorPages.Page, IHasLog
    {
        protected Page()
        {
            Log = new Log("Mvc.Page");
        }

        public string Hi() => "hi";


        protected BlockBuilder BlockBuilder
        {
            get
            {
                if (_cmsBlockLoaded) return _blockBuilder;
                _cmsBlockLoaded = true;
                _blockBuilder = new BlockFromModule(
                        new MvcContainer(),
                        null, // Log,
                        new MvcTenant(new MvcPortalSettings()))
                    .BlockBuilder as BlockBuilder;
                return _blockBuilder;
            }
        }
        private BlockBuilder _blockBuilder;
        private bool _cmsBlockLoaded;

        public ILog Log { get; }
    }
}
