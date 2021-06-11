using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using R = SweetLife.Logic.Repositories.Mssql;
using VM = SweetLife.WebHost.ViewModels.Employee;

namespace SweetLife.WebHost.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public EmployeeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> List(VM.List.ViewModel viewModel)
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<R.Employee.List.IRepository>();

            var employees = await repository.ExecuteAsync(viewModel.SearchString);

            viewModel.Employees = employees
                .Select(e => new VM.ViewModel
                {
                    Id = e.Id,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Patronymic = e.Patronymic,
                    BirthDate = e.BirthDate,
                    Gender = e.Gender,
                    PassportSeries = e.PassportSeries,
                    PassportNumber = e.PassportNumber,
                    PassportReleaseDate = e.PassportReleaseDate,
                    PassportRegistrationAddress = e.PassportRegistrationAddress,
                    TemporaryRegistrationAddress = e.TemporaryRegistrationAddress,
                    MigrationCardSeries = e.MigrationCardSeries,
                    MigrationCardNumber = e.MigrationCardNumber,
                    PatentSeries = e.PatentSeries,
                    PatentNumber = e.PatentNumber,
                    IsFired = e.IsFired,
                    NotificationFileId = e.NotificationFileId,
                    LastTaxReceiptFileId = e.LastTaxReceiptFileId,
                })
                .OrderBy(e => e.LastName)
                .ThenBy(e => e.FirstName)
                .ThenBy(e => e.Patronymic)
                .ThenBy(e => e.BirthDate)
                .ToList();

            return View(viewModel);
        }

        [HttpGet("[controller]/{id:long}")]
        public async Task<IActionResult> Get([Required] long id)
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<R.Employee.GetById.IRepository>();

            var employee = await repository.ExecuteAsync(id);

            if (employee is null)
            {
                return NotFound();
            }

            var viewModel = new VM.Update.ViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                PassportSeries = employee.PassportSeries,
                PassportNumber = employee.PassportNumber,
                PassportReleaseDate = employee.PassportReleaseDate,
                PassportRegistrationAddress = employee.PassportRegistrationAddress,
                TemporaryRegistrationAddress = employee.TemporaryRegistrationAddress,
                MigrationCardSeries = employee.MigrationCardSeries,
                MigrationCardNumber = employee.MigrationCardNumber,
                PatentSeries = employee.PatentSeries,
                PatentNumber = employee.PatentNumber,
                IsFired = employee.IsFired,
                NotificationFileId = employee.NotificationFileId,
                LastTaxReceiptFileId = employee.LastTaxReceiptFileId,
            };

            return View(viewModel);
        }

        [HttpPost("[controller]/{id:long}")]
        [ActionName(nameof(Get))]
        public async Task<IActionResult> Update([Required] long id, VM.Update.ViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<R.Employee.Update.IRepository>();

            await repository.ExecuteAsync(viewModel);

            return RedirectToAction(nameof(Get), new { id });
        }

        [HttpGet("[controller]/{id:long}/Fire")]
        public async Task<IActionResult> Fire([Required] long id)
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<R.Employee.Fire.IRepository>();

            await repository.ExecuteAsync(id);

            return RedirectToAction(nameof(Get), new { id });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName(nameof(Create))]
        public async Task<IActionResult> Insert(VM.Insert.ViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<R.Employee.Insert.IRepository>();

            await repository.ExecuteAsync(viewModel);

            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public async Task<IActionResult> UploadNotificationFile(VM.UploadNotificationFile.ViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<R.Employee.SaveNotification.IRepository>();

            var input = new R.Employee.SaveNotification.Input
            {
                ContentType = viewModel.File.ContentType,
                Content = viewModel.File.OpenReadStream(),
                EmployeeId = viewModel.EmployeeId
            };

            await repository.ExecuteAsync(input);

            return RedirectToAction(nameof(Get), new { id = viewModel.EmployeeId });
        }

        [HttpPost]
        public async Task<IActionResult> UploadLastTaxReceiptFile(VM.UploadLastTaxReceiptFile.ViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<R.Employee.SaveTaxReceipt.IRepository>();

            var input = new R.Employee.SaveTaxReceipt.Input
            {
                ContentType = viewModel.File.ContentType,
                Content = viewModel.File.OpenReadStream(),
                EmployeeId = viewModel.EmployeeId,
                Date = viewModel.PaidDate,
                PaymentAmount = viewModel.PaymentAmount
            };

            await repository.ExecuteAsync(input);

            return RedirectToAction(nameof(Get), new { id = viewModel.EmployeeId });
        }
    }
}
