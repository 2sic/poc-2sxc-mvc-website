using ToSic.Eav.Logging;
using ToSic.Eav.Logging.Simple;
using ToSic.Sxc.Blocks;
using ToSic.Sxc.Mvc.Code;
using ToSic.Sxc.Mvc.Run;
using ToSic.Sxc.Mvc.TestStuff;

namespace ToSic.Sxc.Mvc.RazorPages
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


        public string Hi() => "hi";



    }
}
