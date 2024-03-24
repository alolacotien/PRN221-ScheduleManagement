using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
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


    public List<string> AddDataToDatabase(CsvDataDTO csvData)
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
        
        if (messages.Count > 0)
        {
            return messages;
        }
        
        Models.Schedule schedule = GetScheduleFromData(csvData);
        
        string message = IsValid(schedule);
        if (message != "")
        {
            messages.Add(message);
            return messages;
        }
        
        try
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }
        catch 
        {
            message = FindConstraintError(schedule);
            if (message != "")
            {
                messages.Add(message);
                return messages;
            }
        }

        messages.Add("Saved successfully!");
        return messages;
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