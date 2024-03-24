using System;
using System.Collections.Generic;

namespace Schedule.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int RoomId { get; set; }
        public int SlotId { get; set; }

        public virtual GroupClass Class { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual Slot Slot { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
    }
}
