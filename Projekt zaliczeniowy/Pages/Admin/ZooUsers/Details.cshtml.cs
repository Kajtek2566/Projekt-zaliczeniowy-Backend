using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_zaliczeniowy.ServicesClient;

namespace Labs2024_WebPages.Pages.Admin.ZooUsers
{
    public class DetailsModel : PageModel
    {
        private readonly ZooUserService _zooUserService;

        public DetailsModel(ZooUserService zooUserService)
        {
            _zooUserService = zooUserService;
        }

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
    }
}
