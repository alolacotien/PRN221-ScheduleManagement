using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schedule.DTO;
using Schedule.Models;
using Schedule.Services;

namespace Schedule.Pages.ScheduleMn;

public class ImportCsv : PageModel
{
    private readonly CsvFileService _csvService;
    private readonly DataService _dataService;
    
    public ImportCsv( CsvFileService csvService, DataService dataService)
    {
        _csvService = csvService;
        _dataService = dataService;
    }

    public void OnPostImportCsv(IFormFile? csvFile)
    {
        if (csvFile != null && csvFile.Length > 0)
        {

            string folder = "wwwroot/import";
            string filePath = _csvService.UploadFile(csvFile, folder);
            List<CsvDataDTO> records = _csvService.ReadDataScheduleFromFile(filePath);
            List<string> messages = new List<string>();
            for (int i = 0; i < records.Count; i++)
            {
                string message = _dataService.AddDataToDatabase(records[i]);
                messages.Add(message);
            }

            ViewData["Messages"] = messages;
            ViewData["MessageType"] = messages.Any(msg => msg.Contains("successfully")) ? "alert-success" : "alert-danger";
        }
    }
}