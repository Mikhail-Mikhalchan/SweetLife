using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetLife.Logic.Repositories.Mssql.TaxReceipt.List
{
    public interface IRepository
    {
        Task<IList<IEntity>> ExecuteAsync(DateTime? minDateTime = null, DateTime? maxDateTime = null);
    }
}