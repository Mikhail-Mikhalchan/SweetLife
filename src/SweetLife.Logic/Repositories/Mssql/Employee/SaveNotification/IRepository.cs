using System.Threading.Tasks;

namespace SweetLife.Logic.Repositories.Mssql.Employee.SaveNotification
{
    public interface IRepository
    {
        Task<bool> ExecuteAsync(Input input);
    }
}