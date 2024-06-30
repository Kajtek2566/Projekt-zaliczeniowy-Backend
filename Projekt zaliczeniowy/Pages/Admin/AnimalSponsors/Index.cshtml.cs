using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Infrastructure.Data;


namespace Projekt_zaliczeniowy.Pages.Admin.AnimalSponsors
{
    public class IndexModel : PageModel
    {
        private readonly ZooDbContext _context;

        public IndexModel(ZooDbContext context)
        {
            _context = context;
        }

        public IList<AnimalSponsor> AnimalSponsor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AnimalSponsor = await _context.AnimalSponsors
                .Include(a => a.Animal).ToListAsync();
        }
    }
}
