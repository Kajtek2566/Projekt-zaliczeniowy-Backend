using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Infrastructure.Data;


namespace Projekt_zaliczeniowy.Admin.AnimalSponsors
{
    public class DetailsModel : PageModel
    {
        private readonly ZooDbContext _context;

        public DetailsModel(ZooDbContext context)
        {
            _context = context;
        }

        public AnimalSponsor AnimalSponsor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalsponsor = await _context.AnimalSponsors.FirstOrDefaultAsync(m => m.Id == id);
            if (animalsponsor == null)
            {
                return NotFound();
            }
            else
            {
                AnimalSponsor = animalsponsor;
            }
            return Page();
        }
    }
}
