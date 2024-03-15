using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schedule.Models;

namespace Schedule.Pages.Room
{
    public class IndexModel : PageModel
    {
        private readonly Schedule.Models.ScheduleManagementContext _context;

        public IndexModel(Schedule.Models.ScheduleManagementContext context)
        {
            _context = context;
        }

        public IList<Models.Room> Room { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rooms != null)
            {
                Room = await _context.Rooms
                .Include(r => r.Building).ToListAsync();
            }
        }
    }
}
