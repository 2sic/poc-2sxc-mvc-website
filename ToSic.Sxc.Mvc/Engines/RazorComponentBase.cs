using ToSic.Sxc.Blocks;
using ToSic.Sxc.Mvc.RazorPages;

namespace ToSic.Sxc.Mvc.Engines
{
    public class RazorComponentBase: SxcRazorPage<DummyModel>
    {
        public string VirtualPath;

        public Purpose Purpose;
    }
}
