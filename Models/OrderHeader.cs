﻿namespace marlin.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string OrderID { get; set; }
        public string SourceID { get; set; }
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public string SenderID { get; set; }
        public string ReceiverID { get; set; }
        public string ShopID { get; set; }
        public double Amount { get; set; }
        public double StatusID { get; set; }


        public OrderHeader()
        {

        }
    }
}
