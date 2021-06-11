using System;

namespace SweetLife.Logic.Repositories.Mssql.TaxReceipt
{
    public interface IEntity
    {
        long Id { get; }
        
        long EmployeeId { get; }

        long FileId { get; }

        DateTime Date { get; }

        decimal PaymentAmount { get; }
    }
}