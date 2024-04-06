namespace FPTLongChau.Models
{
    public class Storage
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public DateTime Time { get; set; }
        public List<Product> Products { get; set; }

    }
}
