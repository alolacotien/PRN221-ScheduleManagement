using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schedule.Models;

namespace Schedule.Pages.Slot
{
    public class DetailsModel : PageModel
    {
        private readonly Schedule.Models.ScheduleManagementContext _context;

        public DetailsModel(Schedule.Models.ScheduleManagementContext context)
        {
            _context = context;
        }

      public Models.Slot Slot { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Slots == null)
            {
                return NotFound();
            }

            var slot = await _context.Slots.FirstOrDefaultAsync(m => m.Id == id);
            if (slot == null)
            {
                return NotFound();
            }
            else 
            {
                Slot = slot;
            }
            return Page();
        }
    }
}
