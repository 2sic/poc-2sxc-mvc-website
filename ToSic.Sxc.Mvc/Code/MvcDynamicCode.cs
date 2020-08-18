using ToSic.Eav.Logging;
using ToSic.Eav.Run;
using ToSic.Sxc.Blocks;

namespace ToSic.Sxc.Mvc.Code
{
    public class MvcDynamicCode: Sxc.Code.DynamicCodeRoot
    {
        public MvcDynamicCode(): base("Mvc.CodeRt") { }
        public MvcDynamicCode Init(IBlockBuilder blockBuilder, ILog parentLog) 
            // : base(blockBuilder, Eav.Factory.Resolve<ITenant>(), 10, parentLog)
        {
            base.Init(blockBuilder, Eav.Factory.Resolve<ITenant>(), 10, parentLog);
            return this;
        }
    }
}
