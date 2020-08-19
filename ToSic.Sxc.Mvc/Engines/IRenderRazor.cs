using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using ToSic.Sxc.Code;

namespace ToSic.Sxc.Mvc.Engines
{
    public interface IRenderRazor
    {
        Task<string> RenderToStringAsync<TModel>(string partialName, TModel model, DynamicCodeRoot dynCode = null, Action<RazorView> configure = null);
    }
}