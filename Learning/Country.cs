using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Learning
{
    [ModelBinder(typeof(CustomBinder2))]
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string CountryCode { get; set; } = string.Empty;
    }
}
