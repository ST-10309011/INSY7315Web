using Microsoft.AspNetCore.Http; // Required for IFormFile
using System.ComponentModel.DataAnnotations;

namespace AfterGrad.Models
{
    public class ResourceUploadVM
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string ResourceType { get; set; } = string.Empty;

        [Required]
        public IFormFile ResourceFile { get; set; } = default!; // The uploaded file

        public string Description { get; set; } = string.Empty;
    }
}