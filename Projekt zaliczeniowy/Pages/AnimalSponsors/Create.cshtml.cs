using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Model;
using Infrastructure.Data;

namespace Projekt_zaliczeniowy.AnimalSponsors
{
    public class CreateModel : PageModel
    {
        private readonly ZooDbContext _context;

        public CreateModel(ZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AnimalId"] = new SelectList(_context.Animals, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public AnimalSponsor AnimalSponsor { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AnimalSponsors.Add(AnimalSponsor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
