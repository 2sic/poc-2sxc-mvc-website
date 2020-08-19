using System;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.Extensions.DependencyInjection;
using ToSic.Eav.Logging;
using ToSic.Eav.Logging.Simple;
using ToSic.Sxc.Blocks;

namespace ToSic.Sxc.Mvc.RazorPages
{
    // test, doesn't do anything yet
    public abstract partial class SxcRazorPage<TModel>: Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>
    {
        #region Constructor / DI

        // Source: https://dotnetstories.com/blog/How-to-implement-a-custom-base-class-for-razor-views-in-ASPNET-Core-en-7106773524?o=rss

        [RazorInject]
        public IServiceProvider ServiceProvider { get; set; }

        protected SxcRazorPage()
        {
            Log = new Log("Mvc.SxcRzr");

            var x = ServiceProvider;
            var y = ServiceProvider?.GetService<IServiceProvider>();
        }
        public ILog Log { get; }
        #endregion

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


        //public override Task ExecuteAsync() => throw new NotImplementedException();

        public string Test()
        {
            var x = 7;
            return "hello from test()";
        }

        public string VirtualPath { get; set; }

        public Purpose Purpose { get; set; }

    }
}
