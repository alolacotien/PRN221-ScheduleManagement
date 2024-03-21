using CsvHelper.Configuration;
using Schedule.DTO;

namespace Schedule.Mapper;

public sealed class DataMapper : ClassMap<DataDTO>
{
    public DataMapper()
    {
        Map(m => m.Class).Index(0);
        Map(m => m.Subject).Index(1);
        Map(m => m.Room).Index(2);
        Map(m => m.Teacher).Index(3);
        Map(m => m.TimeSlot).Index(4);
    }
}