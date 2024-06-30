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
    public class DeleteModel : PageModel
    {
        private readonly ZooDbContext _context;

        public DeleteModel(ZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalsponsor = await _context.AnimalSponsors.FindAsync(id);
            if (animalsponsor != null)
            {
                AnimalSponsor = animalsponsor;
                _context.AnimalSponsors.Remove(AnimalSponsor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
