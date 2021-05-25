using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetLife.Abstractions.Repositories.Employee
{
    public interface IRepository
    {
        Task<Models.InsertResult> InsertAsync(IEntity entity);

        Task<Models.UpdateResult> UpdateAsync(IEntity entity);

        Task<Models.DeleteResult> DeleteAsync(long id);

        Task<IEntity> GetByIdAsync(long id);

        Task<IList<IEntity>> GetAsync(int page = 1, int size = 10, string searchString = null);
    }
}