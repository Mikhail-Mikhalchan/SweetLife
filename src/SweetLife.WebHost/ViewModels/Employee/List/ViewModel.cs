using System.Collections.Generic;

namespace SweetLife.WebHost.ViewModels.Employee.List
{
    public class ViewModel
    {
        public string SearchString { get; set; }

        public IList<Employee.ViewModel> Employees { get; set; }
    }
}