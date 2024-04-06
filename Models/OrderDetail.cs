using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTLongChau.Models
{
    public class OrderDetail
    {
        public string ProductId { get; set; }
        public string OrderId { get; set; }
        public Product Product { get; set; } = null;
        public Order Order { get; set; } = null;
        public int Quantity { get; set; }

    }
}
