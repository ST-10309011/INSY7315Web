using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AfterGrad.Models
{
    public class BroadcastMessageVM
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;

        [Required]
        public string SelectedAudience { get; set; } = string.Empty; // e.g., "All Students", "Consultants", "Certain Group"

        public IFormFile? Attachment { get; set; } // Optional attachment
    }
}