﻿using System;
using System.Threading.Tasks;
using ToSic.Eav.Logging;
using ToSic.Eav.Logging.Simple;
using ToSic.Sxc.Blocks;
using ToSic.Sxc.Code;

namespace ToSic.Sxc.Mvc.RazorPages
{
    // test, doesn't do anything yet
    public abstract partial class SxcRazorPageNoModel: Microsoft.AspNetCore.Mvc.Razor.RazorPage
    {
        #region Constructor / DI
        protected SxcRazorPageNoModel()
        {
            Log = new Log("Mvc.SxcRzr");
        }
        public ILog Log { get; }
        #endregion

        #region Properties to identify the block

        //public int Id => _id ?? (_id = GetNumberFromViewData("Id")).Value;
        //private int? _id;

        //public int PageId => _pageId ?? (_pageId = GetNumberFromViewData("PageId")).Value;
        //private int? _pageId;

        //public int AppId => _appId ?? (_appId = GetNumberFromViewData("AppId")).Value;
        //private int? _appId;

        //public Guid Block => _block ?? (_block = GetGuidFromViewData("Block")).Value;
        //private Guid? _block;

        //private int GetNumberFromViewData(string name)
        //{
        //    object idObj = null;
        //    ViewData?.TryGetValue(name, out idObj);
        //    int.TryParse(idObj?.ToString(), out var tempId);
        //    return tempId;
        //}
        //private Guid GetGuidFromViewData(string name)
        //{
        //    object idObj = null;
        //    ViewData?.TryGetValue(name, out idObj);
        //    Guid.TryParse(idObj?.ToString(), out var tempId);
        //    return tempId;
        //}

        #endregion


        //public IBlockBuilder BlockBuilder { get; }

        public IBlockBuilder BlockBuilder => DynCode.BlockBuilder;
    }
}
