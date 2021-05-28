using System.Threading.Tasks;

namespace SweetLife.Logic.Repositories.Mssql.File.GetById
{
    public interface IRepository
    {
        Task<Result> ExecuteAsync(long id);
    }
}
