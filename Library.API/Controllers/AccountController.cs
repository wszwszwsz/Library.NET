using Library.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("api/[controller")]
public class AccountController : ControllerBase
{
    // private readonly IAccountRepository _accountRepository;
    //
    // public AccountController(IAccountRepository _accountRepository)
    // {
    //     _accountRepository = AccountRepository;
    // }
    //
    // [HttpPost("Create")]
    // public async Task<IActionResult> CreateNewLandLordAccount([FromBody] LandLordCreationRequestDto dto)
    // {
    //     await _landLordService.CreateNewLandLordAccountAsync(dto);
    //     return NoContent();
    // }
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };
    //
    // private readonly ILogger<WeatherForecastController> _logger;
    //
    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }
    //
    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //         {
    //             Date = DateTime.Now.AddDays(index),
    //             TemperatureC = Random.Shared.Next(-20, 55),
    //             Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //         })
    //         .ToArray();
    // }
}