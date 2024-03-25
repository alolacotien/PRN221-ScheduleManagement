using Microsoft.EntityFrameworkCore;
using Schedule.DTO;
using Schedule.Models;

namespace Schedule.Services;

public class ValidationService
{
    private readonly ScheduleManagementContext _context;

    public ValidationService(ScheduleManagementContext context)
    {
        _context = context;
    }

    public string CheckSlotAndRoom(Models.Schedule schedule)
    {
        var roomAndSlot = _context.Schedules
            .Include(s => s.Slot)
            .Include(s => s.Room)
            .FirstOrDefault( s => s.SlotId == schedule.SlotId && s.RoomId == schedule.RoomId);
        if (roomAndSlot != null)
        {
            return $"There is already a schedule at Slot {roomAndSlot.Slot.SlotName} in Room {roomAndSlot.Room.Code}";
        }

        return "";
    }
    
    public string CheckSlotAndTeacher(Models.Schedule schedule)
    {
        var teacherAndSlot = _context.Schedules
            .Include(s => s.Slot)
            .Include(s => s.Teacher)
            .FirstOrDefault(s => s.SlotId == schedule.SlotId && s.TeacherId == schedule.TeacherId);
        if (teacherAndSlot != null)
        {
            return $"There is already a schedule at Slot {teacherAndSlot.Slot.SlotName} taught by Teacher {teacherAndSlot.Teacher.Code}";
        }
        return "";
    }
    
    public string CheckSlotAndClass(Models.Schedule schedule)
    {
        var classAndSlot = _context.Schedules
            .Include(s => s.Slot)
            .Include(s => s.Class)
            .FirstOrDefault(s => s.SlotId == schedule.SlotId && s.ClassId == schedule.ClassId);
        if (classAndSlot != null)
        {
            return $"There is already a schedule at Slot {classAndSlot.Slot.SlotName} of Class {classAndSlot.Class.Code}";
        }
        return "";
    }
    
    public string CheckClassAndSubject(Models.Schedule schedule)
    {
        var classAndSubject = _context.Schedules
            .Include(s => s.Subject)
            .Include(s => s.Class)
            .FirstOrDefault(s =>  s.ClassId == schedule.ClassId && s.SubjectId == schedule.SubjectId);
        if (classAndSubject != null)
        {
            return $"Class {classAndSubject.Class.Code} already have 1 slot for subject {classAndSubject.Subject.Code}";
        }

        return "";
    }
    
    public string MessageCheckAvailableData(Models.Schedule schedule)
    {
        string message;

        message = CheckClassAndSubject(schedule);
        if(message != "")
        {
            return message;
        }

        message = CheckSlotAndRoom(schedule);
        if (message != "")
        {
            return message;
        }

        message = CheckSlotAndTeacher(schedule);
        if (message != "")
        {
            return message;
        }

        message = CheckSlotAndClass(schedule);
        if (message != "")
        {
            return message;
        }

        return message;
    }
    
    public List<string> MessageValidateData(CsvDataDTO csvData)
    {
        List<string> messages = new List<string>();

        if (_context.Teachers.FirstOrDefault(t => t.Code == csvData.Teacher) == null)
            messages.Add( $"Teacher {csvData.Teacher} does not exists");
        if (_context.Subjects.FirstOrDefault(t => t.Code == csvData.Subject) == null)
            messages.Add($"Subject {csvData.Subject} does not exists");
        if (_context.GroupClasses.FirstOrDefault(t => t.Code == csvData.Class) == null)
            messages.Add($"Class {csvData.Class} does not exists");
        if (_context.Rooms.FirstOrDefault(t => t.Code == csvData.Room) == null)
            messages.Add($"Room {csvData.Room} does not exists");
        if (_context.Slots.FirstOrDefault(t => t.SlotName == csvData.Slot) == null)
            messages.Add($"Slot {csvData.Slot} does not exists");

        return messages;
    }
}