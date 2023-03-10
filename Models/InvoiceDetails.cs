namespace marlin.Models
{
    public class InvoiceDetails
    {
        public int ID { get; set; }
        public string InvoiceID { get; set; }
        public string ProductID { get; set; }
        public double Unit { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }

        public InvoiceDetails()
        {

        }
    }
}
