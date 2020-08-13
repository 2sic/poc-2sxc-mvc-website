using ToSic.Eav.Logging;
using ToSic.Eav.Logging.Simple;

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
