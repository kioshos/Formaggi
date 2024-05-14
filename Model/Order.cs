﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formaggi.Model
{
    public class Order
    {
        public static int OrderID { get; set; }
        public string OrderCheeseName { get; set; }
        public DateTime OrderDate { get; set; }

        public int OrderNumber {  get; set; }
        public bool OrderStatus {  get; set; }
        public int UsersId { get; set; }
        public Order()
        {
            OrderID = OrderID++;
            OrderCheeseName = String.Empty;
            OrderDate = DateTime.Now;
            OrderStatus = false;
            OrderNumber = 0;
            UsersId = 0;
        }

    }
}
