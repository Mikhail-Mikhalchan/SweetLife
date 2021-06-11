using System;
using A = SweetLife.Logic.Repositories.Mssql.TaxReceipt;

namespace SweetLife.WebHost.ViewModels.TaxReceipt
{
    internal class ViewModel : A.IEntity
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long FileId { get; set; }
        public DateTime Date { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
