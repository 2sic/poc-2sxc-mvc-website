using System;
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

        public virtual IBlockBuilder BlockBuilder
        {
            get
            {
                if (_blockBuilder != null) return _blockBuilder;
                if(_dynCode == null) throw new Exception($"{nameof(BlockBuilder)} is empty, and DynCode isn't created - can't continue. Requires DynCode to be attached");
                return _blockBuilder = _dynCode.BlockBuilder;
            }
            protected set => _blockBuilder = value;
        }
        protected IBlockBuilder _blockBuilder;

    }
}
