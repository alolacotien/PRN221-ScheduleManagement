using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using Schedule.Services;

namespace Schedule.Pages.ScheduleMn;

public class Index : PageModel
{
    private readonly ILogger<IndexModel> _logger;
        private readonly ScheduleManagementContext _context;
        
        [BindProperty]
        public Models.Schedule[,] Data { get; set; } = new Models.Schedule[4, 7];

        public Index(ILogger<IndexModel> logger, ScheduleManagementContext context)
        {
            _logger = logger;
            _context = context;
       
        }

        public Task OnGetAsync(string? classCodeSelected)
        {
            try
            {
                List<Models.Schedule> schedules = classCodeSelected == null ? _context.Schedules.Include(s => s.Slot).Include(s => s.Teacher).Include(s => s.Subject).Include(s => s.Class).Include(s => s.Room).ToList()
                                                    : _context.Schedules.Include(s => s.Slot).Include(s => s.Teacher).Include(s => s.Subject).Include(s => s.Class).Include(s => s.Room).Where(x => x.Class.Code == classCodeSelected).ToList();
                foreach (var item in schedules)
                {
                    if (item.Slot.SlotName[0] == 'A')
                    {
                        int daySlot1 = Int32.Parse(item.Slot.SlotName[1].ToString());
                        int daySlot2 = Int32.Parse(item.Slot.SlotName[2].ToString());
                        Data[0, daySlot1 - 2] = item;
                        Data[1, daySlot2 - 2] = item;
                    }
                    else if (item.Slot.SlotName[0] == 'P')
                    {
                        int daySlot1 = Int32.Parse(item.Slot.SlotName[1].ToString());
                        int daySlot2 = Int32.Parse(item.Slot.SlotName[2].ToString());
                        Data[2, daySlot1 - 2] = item;
                        Data[3, daySlot2 - 2] = item;
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }
}