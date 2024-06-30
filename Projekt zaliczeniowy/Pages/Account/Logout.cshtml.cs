using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Projekt_zaliczeniowy.ServicesClient;

namespace Projekt_zaliczeniowy.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly JwtService _jwtService;

        public LogoutModel(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public IActionResult OnGet()
        {
            _jwtService.RemoveToken();
            return RedirectToPage("/Index");
        }
    }
}
