using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_zaliczeniowy.ServicesClient;
using Domain.DTO;

namespace EditModel.Pages.Admin.ZooUsers
{
    public class DeleteModel : PageModel
    {
        private readonly ZooUserService _zooUserService;

        public DeleteModel(ZooUserService zooUserService)
        {
            _zooUserService = zooUserService;
        }

        [BindProperty]
        public ZooUserDTO ZooUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ZooUser = await _zooUserService.GetUserByIdAsync(id);

            if (ZooUser == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _zooUserService.DeleteUserAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
