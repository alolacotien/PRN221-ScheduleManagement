using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schedule.Models;

namespace Schedule.Pages.Subject
{
    public class IndexModel : PageModel
    {
        private readonly Schedule.Models.ScheduleManagementContext _context;

        public IndexModel(Schedule.Models.ScheduleManagementContext context)
        {
            _context = context;
        }

        public IList<Models.Subject> Subject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subjects != null)
            {
                Subject = await _context.Subjects.ToListAsync();
            }
        }
    }
}
