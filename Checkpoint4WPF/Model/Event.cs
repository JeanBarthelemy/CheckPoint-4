using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint4WPF
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<ShowEvent> ManyShowEvents { get; set; } = new List<ShowEvent>();


        public Event(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public Event()
        {

        }
    }
}
