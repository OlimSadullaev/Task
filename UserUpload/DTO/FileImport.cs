using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UserUpload.DTO
{
    public class FileImport
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile ImportFile { get; set; }
    }
}
