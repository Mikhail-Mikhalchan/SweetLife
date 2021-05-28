using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SweetLife.WebHost.ViewModels.Employee.UploadNotificationFile
{
    public class ViewModel
    {
        [Required]
        public long EmployeeId { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}