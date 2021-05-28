using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SweetLife.WebHost.ViewModels.Employee.UploadLastTaxReceiptFile
{
    public class ViewModel
    {
        [Required]
        public long EmployeeId { get; set; }

        [Required]
        public DateTime PaidDate { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}