namespace SweetLife.Logic.Repositories.Mssql.TaxReceipt.List
{
    public interface IEntity : TaxReceipt.IEntity
    {
        string EmployeeName { get; set; }
    }
}
