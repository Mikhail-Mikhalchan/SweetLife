using System.Threading.Tasks;

namespace SweetLife.Logic.Repositories.Mssql.Employee.Fire
{
    public interface IRepository
    {
        Task<bool> ExecuteAsync(long id);
    }
}