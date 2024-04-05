using System.ComponentModel.DataAnnotations;

namespace FPTLongChau.Models
{
    public class Product
    {
        public string Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string CategoryId {  get; set; }
        public Category Category { get; set; }
    }
}
