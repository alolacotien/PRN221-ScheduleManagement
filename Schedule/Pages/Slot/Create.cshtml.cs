using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schedule.Models;

namespace Schedule.Pages.Slot
{
    public class CreateModel : PageModel
    {
        private readonly Schedule.Models.ScheduleManagementContext _context;

        public CreateModel(Schedule.Models.ScheduleManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Slot Slot { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Slots == null || Slot == null)
            {
                return Page();
            }

            _context.Slots.Add(Slot);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
