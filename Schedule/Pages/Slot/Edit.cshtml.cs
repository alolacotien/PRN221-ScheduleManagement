using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schedule.Models;

namespace Schedule.Pages.Slot
{
    public class EditModel : PageModel
    {
        private readonly Schedule.Models.ScheduleManagementContext _context;

        public EditModel(Schedule.Models.ScheduleManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Slot Slot { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Slots == null)
            {
                return NotFound();
            }

            var slot =  await _context.Slots.FirstOrDefaultAsync(m => m.Id == id);
            if (slot == null)
            {
                return NotFound();
            }
            Slot = slot;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Slot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlotExists(Slot.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SlotExists(int id)
        {
          return (_context.Slots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
