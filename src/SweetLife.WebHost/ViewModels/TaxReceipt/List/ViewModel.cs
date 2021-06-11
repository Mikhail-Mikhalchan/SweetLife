using System;
using System.Collections.Generic;
using System.Linq;

using A = SweetLife.Logic.Repositories.Mssql.TaxReceipt;

namespace SweetLife.WebHost.ViewModels.TaxReceipt.List
{
    public class ViewModel
    {
        public IList<A.List.IEntity> Items { get; set; }

        public decimal TotalAmount => Items?.Any() is true ? Items.Sum(i => i.PaymentAmount) : 0;

        public DateTime? MinDateTime { get; set; } = DateTime.Today;

        public DateTime? MaxDateTime { get; set; } = DateTime.Today;
    }
}
