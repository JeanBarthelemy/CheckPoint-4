using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using Checkpoint4WPF;
using Newtonsoft.Json;


namespace Checkpoint4Nancy
{
    public class OrderModule : NancyModule
    {
        public NancyContext Context { get; set; }

        public List<Order> ordersList = DisplayInformation.GetAllOrders();

        public OrderModule()
        {
            Context = new NancyContext();

            Get("/Orders", parameters => GetAllOrders(ordersList));
        }

        public string GetAllOrders(List<Order> orderList)
        {
            string jsonOrders = "";
            string jsonOrder = "";
            //for(int i = 0; i < orderList.Count; i++)
            foreach(Order order in orderList)
            {
                jsonOrder = JsonConvert.SerializeObject(order);
                jsonOrders += jsonOrder + "\n" + "\n";
            }
            return jsonOrders;
        }
    }
}
