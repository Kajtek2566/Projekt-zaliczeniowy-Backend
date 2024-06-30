using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Services;
using Domain.DTO;

namespace Projekt_zaliczeniowy.Pages.Admin.ZooUsers
{
    public class EditModel : PageModel
    {
        private readonly ZooUserService _zooUserService;

        public EditModel(ZooUserService zooUserService)
        {
            _zooUserService = zooUserService;
        }

        [BindProperty]
        public ZooUserDTO ZooUser { get; set; }

        public List<SelectListItem> RoleOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ZooUser = await _zooUserService.GetUserByIdAsync(id);

            if (ZooUser == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _zooUserService.UpdateUserAsync(ZooUser);
            return RedirectToPage("./Index");
        }
    }
}
