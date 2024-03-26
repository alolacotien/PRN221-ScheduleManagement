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

        foreach (var s in schedules)
        {
            if (s.Slot.SlotName[0] == 'A')
            {
                int morning1 = Int32.Parse(s.Slot.SlotName[1].ToString());
                int morning2 = Int32.Parse(s.Slot.SlotName[2].ToString());

                if (morning1 < 2 && morning2 >= 2)
                {
                    Data[1, morning2 - 2] = s;
                }
                else if (morning2 < 2 && morning1 >= 2)
                {
                    Data[0, morning1 - 2] = s;
                }
                else
                {
                    Data[0, morning1 - 2] = s;
                    Data[1, morning2 - 2] = s;
                }
            }
            else if (s.Slot.SlotName[0] == 'P')
            {
                int afternoon1 = Int32.Parse(s.Slot.SlotName[1].ToString());
                int afternoon2 = Int32.Parse(s.Slot.SlotName[2].ToString());

                if (afternoon1 < 2 && afternoon2 >= 2)
                {
                    Data[3, afternoon2 - 2] = s;
                }
                else if (afternoon2 < 2 && afternoon1 >= 2)
                {
                    Data[2, afternoon1 - 2] = s;
                }
                else
                {
                    Data[2, afternoon1 - 2] = s;
                    Data[3, afternoon2 - 2] = s;
                }
            }
        }
    }

    public void OnPostFilter()
    {
        GetData();
    }
}