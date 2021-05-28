using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using R = SweetLife.Logic.Repositories.Mssql.File;

namespace SweetLife.WebHost.Controllers
{
    public class FileController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public FileController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet("file/{id:long}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var scope = _serviceProvider.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            var repository = serviceProvider.GetRequiredService<R.GetById.IRepository>();
            var result = await repository.ExecuteAsync(id);

            if (result.Content == null)
            {
                return NotFound();
            }

            Response.Headers.Add("Cache-Control", "public, max-age=31536000");

            return new GetByIdActionResult(result, scope);
        }
    }

    public class GetByIdActionResult : IActionResult
    {
        private readonly R.GetById.Result _result;
        private readonly IServiceScope _scope;

        public GetByIdActionResult(R.GetById.Result result, IServiceScope scope)
        {
            _result = result;
            _scope = scope;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var action = new FileStreamResult(_result.Content, _result.ContentType);
            await action.ExecuteResultAsync(context);

            _result?.Dispose();
            _scope?.Dispose();
        }
    }
}
