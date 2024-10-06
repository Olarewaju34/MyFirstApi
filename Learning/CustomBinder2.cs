using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyFirstApi.Learning
{
    public class CustomBinder2 : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(modelName);
            var result = value.FirstValue;
            if (!int.TryParse(result, out var id))
            {
                return Task.CompletedTask;
            }
            var model = new Country()
            {
                Id = id,
                Name = "Lanrewaju",
                CountryCode = "7000",
                Population = 50000
            };
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;

        }
    }
}
