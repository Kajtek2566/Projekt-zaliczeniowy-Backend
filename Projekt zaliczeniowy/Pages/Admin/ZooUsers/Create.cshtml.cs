using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_zaliczeniowy.ServicesClient;

namespace Projekt_zaliczeniowy.Pages.Admin.ZooUsers
{
    public class CreateModel : PageModel
    {
        private readonly ZooUserService _zooUserService;

        public CreateModel(ZooUserService userService)
        {
            _zooUserService = userService;
        }

        [BindProperty]
        public ZooUser Input { get; set; }

        public List<SelectListItem> RoleOptions { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _zooUserService.CreateUserAsync(Input);
            return RedirectToPage("./Index");
        }
    }
}
