using CsvHelper.Configuration;
using Schedule.DTO;

namespace Schedule.Mapper;

public sealed class DataMapper : ClassMap<CsvDataDTO>
{
    public DataMapper()
    {
        Map(m => m.Class).Index(0);
        Map(m => m.Subject).Index(1);
        Map(m => m.Room).Index(2);
        Map(m => m.Teacher).Index(3);
        Map(m => m.Slot).Index(4);
    }
}