using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schedule.Models;

namespace Schedule.Pages.Class
{
    public class DeleteModel : PageModel
    {
        private readonly Schedule.Models.ScheduleManagementContext _context;

        public DeleteModel(Schedule.Models.ScheduleManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public GroupClass GroupClass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GroupClasses == null)
            {
                return NotFound();
            }

            var groupclass = await _context.GroupClasses.FirstOrDefaultAsync(m => m.Id == id);

            if (groupclass == null)
            {
                return NotFound();
            }
            else 
            {
                GroupClass = groupclass;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.GroupClasses == null)
            {
                return NotFound();
            }
            var groupclass = await _context.GroupClasses.FindAsync(id);

            if (groupclass != null)
            {
                GroupClass = groupclass;
                _context.GroupClasses.Remove(GroupClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
