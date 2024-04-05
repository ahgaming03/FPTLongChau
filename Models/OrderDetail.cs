namespace FPTLongChau.Models
{
    public class OrderDetail
    {
        public string OrderId {  get; set; }
        public Order Order { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }



    }
}
