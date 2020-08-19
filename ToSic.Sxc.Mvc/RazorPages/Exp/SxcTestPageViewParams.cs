using System;
using ToSic.Sxc.Blocks;
using ToSic.Sxc.Mvc.Dev;

namespace ToSic.Sxc.Mvc.RazorPages.Exp
{
    public abstract class SxcTestPageViewParams<TModel>: SxcRazorPage<TModel>
    {
        protected SxcTestPageViewParams()
        {
            Log.Rename("Mvc.SxcRzr");
        }

        #region Properties to identify the block

        public int Id => _id ?? (_id = GetNumberFromViewData("Id")).Value;
        private int? _id;

        public int PageId => _pageId ?? (_pageId = GetNumberFromViewData("PageId")).Value;
        private int? _pageId;

        public int AppId => _appId ?? (_appId = GetNumberFromViewData("AppId")).Value;
        private int? _appId;

        public Guid Block => _block ?? (_block = GetGuidFromViewData("Block")).Value;
        private Guid? _block;

        private int GetNumberFromViewData(string name)
        {
            object idObj = null;
            ViewData?.TryGetValue(name, out idObj);
            int.TryParse(idObj?.ToString(), out var tempId);
            return tempId;
        }
        private Guid GetGuidFromViewData(string name)
        {
            object idObj = null;
            ViewData?.TryGetValue(name, out idObj);
            Guid.TryParse(idObj?.ToString(), out var tempId);
            return tempId;
        }

        #endregion


        public override IBlockBuilder BlockBuilder
        {
            get
            {
                if (_blockLoaded) return _blockBuilder;
                _blockLoaded = true;
                _blockBuilder = SxcMvcTempEngine.CreateBuilder(TestIds.PrimaryZone, PageId, Id, AppId, Block, Log);
                return _blockBuilder;
            }
        }

    }
}
