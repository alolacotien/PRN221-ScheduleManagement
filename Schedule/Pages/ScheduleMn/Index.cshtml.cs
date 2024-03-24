using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using Schedule.Services;

namespace Schedule.Pages.ScheduleMn;

public class Index : PageModel
{
    private readonly ScheduleManagementContext _context;

    public Models.Schedule[,] Data { get; set; } = new Models.Schedule[4, 7];

    [BindProperty] public int ClassIdSelected { get; set; }
    public List<GroupClass> Classes { get; set; }

    public Index(ScheduleManagementContext context)
    {
        _context = context;
    }

    public void OnGetAsync()
    {
        GetData();
    }

    public void GetData()
    {
        Classes = _context.GroupClasses.ToList();

        List<Models.Schedule> schedules = _context.Schedules
            .Where(s => ClassIdSelected == 0 || s.ClassId == ClassIdSelected)
            .Include(s => s.Slot)
            .Include(s => s.Teacher)
            .Include(s => s.Subject)
            .Include(s => s.Class)
            .Include(s => s.Room)
            .ToList();
        
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

    public void OnPostFilter()
    {
        GetData();
    }
}