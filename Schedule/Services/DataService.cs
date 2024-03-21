using Schedule.DTO;
using Schedule.Models;

namespace Schedule.Services;

public class DataService
{
    private ScheduleManagementContext _context;

    private SlotService SlotService;

    public DataService(ScheduleManagementContext context)
    {
        _context = context;
        
    }

    public int IsExist(DataDTO data)
    {
        string roomCode = data.Room;
        if (_context.Teachers.FirstOrDefault(t => t.Code == data.Teacher) == null) return 1;
        if (_context.Subjects.FirstOrDefault(t => t.Code == data.Subject) == null) return 2;
        if (_context.GroupClasses.FirstOrDefault(t => t.Code == data.Class) == null) return 3;
        if (_context.Rooms.FirstOrDefault(t =>t.Code == roomCode) == null) return 4;
        if (_context.Slots.FirstOrDefault(t => t.SlotName == data.TimeSlot) == null) return 5;

        return 0;
    }

    /*private Models.Schedule GetInitData(DataDTO data)
    {
        
    }*/
    
    public void SaveToDb(List<Models.Schedule> schedules)
    {
        foreach (Models.Schedule s in schedules)
        {
            _context.Add(s);
        }
        _context.SaveChanges();
    }
}