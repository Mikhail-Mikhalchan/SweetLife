using System;
using System.IO;

namespace SweetLife.Logic.Repositories.Mssql.Employee.SaveTaxReceipt
{
    public class Input
    {
        public long EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public Stream Content { get; set; }

        public string ContentType { get; set; }

        public decimal PaymentAmount { get; set; }
    }
}