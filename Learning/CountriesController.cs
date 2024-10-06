using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Learning
{
    [Route("api/[controller]")]
    [ApiController]

    public class CountriesController : ControllerBase
    {
        [HttpPost("{id}")]
        public IActionResult AddCountry([FromRoute] int id, [FromBody] Country model, [FromHeader] string developer)
        {
            return Ok($"Name = {developer}");
        }
        [HttpGet("search")]
        public IActionResult SearchCountries([ModelBinder(typeof(CustomModelBinder))] string[] countries)
        {
            return Ok(countries);
        }
        [HttpGet("{id}")]
        public IActionResult CountryDetails([ModelBinder(Name = "Id")] Country country)
        {
            return Ok(country);
        }
        [HttpGet("name")]
        public IActionResult GetName([FromServices] IProductRepository productRepository)
        {
            var name = productRepository.GetName();
            return Ok(name);
        }


    }
}
