using System;

namespace SweetLife.Logic.Repositories.Mssql.TaxReceipt
{
    internal class Entity : IEntity
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long FileId { get; set; }
        public DateTime Date { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
