﻿using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Models
{
    public class Product
    {
        public string Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Storage Storage { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Supplier>Suppliers { get; set; }
        public List<Unit> Units { get; set; }
    }
}
