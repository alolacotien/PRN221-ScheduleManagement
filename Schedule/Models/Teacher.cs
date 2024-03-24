using System;
using System.Collections.Generic;

namespace Schedule.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
