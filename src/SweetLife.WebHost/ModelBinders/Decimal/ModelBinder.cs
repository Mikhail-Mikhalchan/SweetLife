using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SweetLife.WebHost.ModelBinders.Decimal
{
    public class ModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            if (!decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var decimalValue))
            {
                // Error
                bindingContext.ModelState.TryAddModelError(
                    bindingContext.ModelName,
                    "Поле '{0}' должно быть числом.");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(decimalValue);
            return Task.CompletedTask;
        }
    }
}
