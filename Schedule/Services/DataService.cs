using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Schedule.DTO;
using Schedule.Mapper;
using Schedule.Models;

namespace Schedule.Services;

public class DataService
{
    private readonly ScheduleManagementContext _context;



    public DataService(ScheduleManagementContext context)
    {
        _context = context;
    }

    
    
    public string AddDataToDatabase(CsvDataDTO data)
    {
        int messageId = IsExist(data);
        if (messageId == 0)
        {
            Models.Schedule schedule = GetScheduleFromData(data);

            string message = IsValid(schedule);
            if (message != "")
            {
                return message;
            }

            try
            {
                _context.Schedules.Add(schedule);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return FindConstraintError(schedule);
            }
        }
        else
        {
            if (messageId == 1)
            {
                return "Teacher code do not exists";
            }

            if (messageId == 2)
            {
                return "Subject code do not exists";
            }

            if (messageId == 3)
            {
                return "Class code do not exists";
            }

            if (messageId == 4)
            {
                return "Room code do not exists";
            }

            if (messageId == 5)
            {
                return "Wrong slot template!";
            }
        }


        return "Saved successfully!";
    }

    private int IsExist(CsvDataDTO csvData)
    {
        string roomCode = csvData.Room;
        if (_context.Teachers.FirstOrDefault(t => t.Code == csvData.Teacher) == null) return 1;
        if (_context.Subjects.FirstOrDefault(t => t.Code == csvData.Subject) == null) return 2;
        if (_context.GroupClasses.FirstOrDefault(t => t.Code == csvData.Class) == null) return 3;
        if (_context.Rooms.FirstOrDefault(t => t.Code == roomCode) == null) return 4;
        if (_context.Slots.FirstOrDefault(t => t.SlotName == csvData.Slot) == null) return 5;

        return 0;
    }

    private Models.Schedule GetScheduleFromData(CsvDataDTO data)
    {
        var schedule = new Models.Schedule
        {
            RoomId = _context.Rooms.FirstOrDefault(r => r.Code == data.Room)!.Id,
            SubjectId = _context.Subjects.FirstOrDefault(s => s.Code == data.Subject)!.Id,
            ClassId = _context.GroupClasses.FirstOrDefault(c => c.Code == data.Class)!.Id,
            TeacherId = _context.Teachers.FirstOrDefault(t => t.Code == data.Teacher)!.Id,
            SlotId = _context.Slots.FirstOrDefault(s => s.SlotName == data.Slot)!.Id
        };

        return schedule;
    }

    private string IsValid(Models.Schedule schedule)
    {
        ValidationService validationService = new ValidationService(_context);

        return validationService.MessageValidateSchedule(schedule);
    }

    private string FindConstraintError(Models.Schedule schedule)
    {
        ValidationService validationService = new ValidationService(_context);
        string message;
        message = validationService.CheckSlotAndRoom(schedule);
        if (message != "") return message;

        message = validationService.CheckSlotAndTeacher(schedule);
        if (message != "") return message;

        message = validationService.CheckSlotAndClass(schedule);
        if (message != "") return message;

        message = validationService.CheckClassAndSubject(schedule);
        if (message != "") return message;

        return "";
    }

    public void DeleteAllData()
    {
        var schedules = _context.Schedules.ToList();
        _context.Schedules.RemoveRange(schedules);
        _context.SaveChanges();
    }
}