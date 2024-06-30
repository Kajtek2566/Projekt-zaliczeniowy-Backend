using Domain.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_zaliczeniowy.ServicesClient;

namespace Projekt_zaliczeniowy.Pages.Admin.ZooUsers
{
    public class IndexModel : PageModel
    {
        private readonly ZooUserService _zooUserService;

        public IndexModel(ZooUserService zooUserService)
        {
            _zooUserService = zooUserService;
        }

        public IList<ZooUser> ZooUsers { get; set; }

        public async Task OnGetAsync()
        {
            ZooUsers = await _zooUserService.GetAllUsersAsync();
        }
    }
}
