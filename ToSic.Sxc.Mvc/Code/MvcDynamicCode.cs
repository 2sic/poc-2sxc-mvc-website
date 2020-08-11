using ToSic.Eav.Logging;
using ToSic.Eav.Run;
using ToSic.Sxc.Blocks;

namespace ToSic.Sxc.Mvc.Code
{
    public class MvcDynamicCode: Sxc.Code.DynamicCodeRoot
    {
        public MvcDynamicCode(IBlockBuilder blockBuilder, ILog parentLog) 
            : base(blockBuilder, Eav.Factory.Resolve<ITenant>(), 10, parentLog)
        {
        }
    }
}
