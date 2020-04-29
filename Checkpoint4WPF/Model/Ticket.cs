using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint4WPF
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string ShowName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TicketPrice { get; set; }

        public Ticket(string showName, DateTime startTime, DateTime endTime, double ticketPrice)
        {
            ShowName = showName;
            StartTime = startTime;
            EndTime = endTime;
            TicketPrice = ticketPrice;
        }

        public Ticket()
        {

        }
    }
}
