using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToSic.Eav.Data;

namespace Website.Pages
{
    public class EavCoreModel : PageModel
    {
        public void OnGet()
        {
            EntityInBlog = ToSic.Eav.Apps.State.Get(78).List.First();
        }

        public IEntity EntityInBlog;
    }
}