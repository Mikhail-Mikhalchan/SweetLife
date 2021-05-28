using System.Threading.Tasks;

namespace SweetLife.Logic.Repositories.Mssql.Employee.Insert
{
    public interface IRepository
    {
        Task<Result> ExecuteAsync(IEntity entity);
    }
}