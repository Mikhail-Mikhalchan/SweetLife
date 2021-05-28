using System.Threading.Tasks;

namespace SweetLife.Logic.Repositories.Mssql.Employee.GetById
{
    public interface IRepository
    {
        Task<IEntity> ExecuteAsync(long id);
    }
}