using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MB = SweetLife.WebHost.ModelBinders;

namespace SweetLife.WebHost.ViewModels.Employee.UploadLastTaxReceiptFile
{
    public class ViewModel
    {
        [Required]
        public long EmployeeId { get; set; }

        [Required]
        public DateTime PaidDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [ModelBinder(typeof(MB.Decimal.ModelBinder))]
        public decimal PaymentAmount { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}