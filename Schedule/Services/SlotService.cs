using Schedule.Models;

namespace Schedule.Services;

public class SlotService
{
    private string[] _validSlots = { "A24", "A35", "A46", "A52", "A63", "P23", "P35", "P46", "P53", "P63" };
    private static DateTime _initialDate = new DateTime(2024, 04, 29);
    private ScheduleManagementContext _context;

    public SlotService(ScheduleManagementContext context)
    {
        _context = context;
    }

    public bool IsSlotValid(string slotName)
    {
        foreach (var slot in _validSlots)
        {
            if(slotName.Equals(slot)) return true;
        }
        return false;
    }
}