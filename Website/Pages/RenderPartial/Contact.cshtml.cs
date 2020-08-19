using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPartialToString.Services;

namespace Website.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IRazorPartialToStringRenderer _renderer;
        //private readonly IEmailService _emailer;
        public ContactModel(IRazorPartialToStringRenderer renderer/*, IEmailService emailer*/)
        {
            _renderer = renderer;
            //_emailer = emailer;
        }
        [BindProperty]
        public ContactForm ContactForm { get; set; }
        [TempData]
        public string PostResult { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var body = await _renderer.RenderPartialToStringAsync("RenderPartial/_RenderPartialMail", ContactForm);
            //await _emailer.SendAsync(ContactForm.Name, ContactForm.Email, ContactForm.Subject, body);
            PostResult = body; // "Check your specified pickup directory";
            return RedirectToPage();
        }
    }
    public class ContactForm
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public Priority Priority { get; set; }
    }
    public enum Priority
    {
        Low, Medium, High
    }
}