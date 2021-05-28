using System.IO;

namespace SweetLife.Logic.Repositories.Mssql.Employee.SaveNotification
{
    public class Input
    {
        public long EmployeeId { get; set; }
        public Stream Content { get; set; }
        public string ContentType { get; set; }
    }
}