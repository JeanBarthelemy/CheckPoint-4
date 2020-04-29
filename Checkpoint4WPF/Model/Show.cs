using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Checkpoint4WPF
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Troupe Troupe { get; set; }
        public string Description { get; set; }
        public List<Event> Events { get; set; }
        public ICollection<ShowEvent> ManyShowEvents { get; set; } = new List<ShowEvent>();
        public double TicketPrice { get; set; }

        public Show(string name, Troupe troupe, string description, List<Event> events, double ticketPrice)
        {
            Name = name;
            Troupe = troupe;
            Description = description;
            Events = events;
            TicketPrice = ticketPrice;
        }

        public Show()
        {

        }
    }
}
