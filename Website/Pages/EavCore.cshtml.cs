using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToSic.Eav;
using ToSic.Eav.Apps;
using ToSic.Eav.Data;
using ToSic.Eav.DataSources;
using ToSic.Eav.LookUp;

namespace Website.Pages
{
    public class EavCoreModel : PageModel
    {
        public void OnGet()
        {
            EntityInBlog = ToSic.Eav.Apps.State.Get(78).List.First();

        }

        public IEntity EntityInBlog;

        private ILookUpEngine ConfigProvider => new LookUpEngine(null);

        public IDataSource BlogRoot()
        {
            var dsFact = new DataSource();
            return dsFact.GetDataSource<IAppRoot>(new AppIdentity(2, 78), null, ConfigProvider);
        }

        public IDataSource BlogTags()
        {
            var dsFact = new DataSource();
            var dsBlog = BlogRoot();
            var dsFilter = dsFact.GetDataSource<EntityTypeFilter>(dsBlog, dsBlog);
            dsFilter.TypeName = "Tag";
            return dsFilter;
        }
    }
}