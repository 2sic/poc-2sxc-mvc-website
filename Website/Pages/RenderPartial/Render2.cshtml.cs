using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToSic.Sxc.Mvc;
using ToSic.Sxc.Mvc.Engines;

namespace Website.Pages.RenderPartial
{
    public class Render2Model : PageModel
    {
        private readonly IRenderRazor _renderer;
        public Render2Model(IRenderRazor renderer)
        {
            _renderer = renderer;
        }

        public async Task OnGetAsync()
        {
            var dynCode = SxcMvcTempEngine.CreateDynCode(TestConstants.BlogT, TestConstants.BlogP,
                TestConstants.BlogI, TestConstants.BlogA, TestConstants.BlogB, null);


            InnerRender = await _renderer.RenderToStringAsync(
                "/wwwroot/2sxc/Blog App/_1 Main blog view.cshtml",
                new ContactForm
                {
                    Email = "something@somewhere",
                    Message = "Hello message!",
                    Name = "The Dude",
                    Priority = Priority.Medium,
                    Subject = "This is the subject"
                },
                dynCode);
        }


        public string InnerRender;
    }
    
}