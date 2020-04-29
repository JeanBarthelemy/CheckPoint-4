using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint4WPF
{
    public class Order
    {
        public Guid Id { get; set; }
        public Ticket Ticket { get; set; }
        public int Quantity { get; set; }
        public double OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public Order(Ticket ticket, int quantity, double orderPrice, DateTime orderDate)
        {
            Ticket = ticket;
            Quantity = quantity;
            OrderPrice = orderPrice;
            OrderDate = orderDate;
        }

        public Order()
        {

        }
    }
}
