using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Schedule.DTO;
using Schedule.Mapper;

namespace Schedule.Services;

public class CsvFileService
{
    private readonly IWebHostEnvironment _environment;
    private readonly DataService _dataService;

    public CsvFileService(IWebHostEnvironment environment, DataService dataService)
    {
        _environment = environment;
        _dataService = dataService;
    }
    
    public List<CsvDataDTO> ReadDataScheduleFromFile(string path)
    {
        if (File.Exists(path))
        {
            using StreamReader reader = new StreamReader(path);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                MissingFieldFound = null
            };

            using var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<DataMapper>();
            List<CsvDataDTO> listSchedule = csv.GetRecords<CsvDataDTO>().ToList();

            return listSchedule;
        }

        return null;
    }

    public string UploadFile(IFormFile fileUpload, string folder)
    {
        _dataService.DeleteAllData();
        string pathDirectory = Path.Combine(_environment.ContentRootPath, folder);

        if (!Directory.Exists(pathDirectory))
        {
            Directory.CreateDirectory(pathDirectory);
        }

        string fileNameSave = Path.GetFileNameWithoutExtension(fileUpload.FileName) +
                              DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss") + Path.GetExtension(fileUpload.FileName);
        
        var file = Path.Combine(pathDirectory, fileNameSave);

        using (var fileStream = new FileStream(file, FileMode.Create))
        {
            fileUpload.CopyTo(fileStream);
        }

        return file;
    }
}