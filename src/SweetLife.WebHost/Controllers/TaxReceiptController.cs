using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using R = SweetLife.Logic.Repositories.Mssql.TaxReceipt;
using VM = SweetLife.WebHost.ViewModels.TaxReceipt;

namespace SweetLife.WebHost.Controllers
{
    public class TaxReceiptController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public TaxReceiptController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> List(DateTime? minDateTime = null, DateTime? maxDateTime = null)
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<R.List.IRepository>();

            var today = DateTime.Today;

            minDateTime ??= new DateTime(today.Year, today.Month, 1);
            maxDateTime ??= new DateTime(minDateTime.Value.Year, minDateTime.Value.Month, 1).AddMonths(1).AddSeconds(-1);

            var viewModel = new VM.List.ViewModel
            {
                Items = await repository.ExecuteAsync(minDateTime, maxDateTime),
                MinDateTime = minDateTime,
                MaxDateTime = maxDateTime
            };

            return View(viewModel);
        }
    }
}
