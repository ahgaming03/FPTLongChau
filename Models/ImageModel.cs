using System.ComponentModel;

namespace FPTLongChau.Models
{
    public class ImageModel
    {
        [DisplayName("Upload File")]
        public IFormFile? File { get; set; }
    }
}
