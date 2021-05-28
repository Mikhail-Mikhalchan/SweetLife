using System.Threading.Tasks;

namespace SweetLife.Logic.Repositories.Mssql.Employee.SaveTaxReceipt
{
    public interface IRepository
    {
        Task<bool> ExecuteAsync(Input input);
    }
}