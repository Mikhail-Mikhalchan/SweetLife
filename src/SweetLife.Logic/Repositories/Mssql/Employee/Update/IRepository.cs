using System.Threading.Tasks;

namespace SweetLife.Logic.Repositories.Mssql.Employee.Update
{
    public interface IRepository
    {
        Task<int> ExecuteAsync(IEntity entity);
    }
}