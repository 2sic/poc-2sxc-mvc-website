using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Website.ViewComponents
{
    public class ThirdViewComponent: ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = new List<string>()
            {
                "Hello",
                "There",
                "something"
            };
            return View(items);
        }
    }
}
