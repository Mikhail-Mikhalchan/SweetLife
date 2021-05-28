using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetLife.Logic.Repositories.Mssql.Employee.List
{
    public interface IRepository
    {
        Task<IList<IEntity>> ExecuteAsync(string searchString = null);
    }
}