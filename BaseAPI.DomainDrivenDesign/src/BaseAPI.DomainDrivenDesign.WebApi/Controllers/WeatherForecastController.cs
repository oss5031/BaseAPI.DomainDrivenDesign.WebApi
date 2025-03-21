
using AutoMapper;
using BaseAPI.DomainDrivenDesign.Application.Models.WeatherForecast;
using BaseAPI.DomainDrivenDesign.Application.Services.Interfaces;
using BaseAPI.DomainDrivenDesign.WebApi.Models.WeatherForecast;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.DomainDrivenDesign.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService weatherForecastService;
    private readonly IMapper mapper;
    private readonly ILogger<WeatherForecastController> logger;

    public WeatherForecastController(IWeatherForecastService weatherForecastService, IMapper mapper, ILogger<WeatherForecastController> logger)
    {
        this.weatherForecastService = weatherForecastService;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetWeatherForecastResponseModel>), 200)]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var weatherForecasts = await weatherForecastService.GetAll(ct);

        var response = mapper.Map<IEnumerable<GetWeatherForecastResponseModel>>(weatherForecasts);

        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetWeatherForecastResponseModel), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var weatherForecast = await weatherForecastService.GetById(id, ct);

        if (weatherForecast == null)
        {
            return NotFound();
        }

        var response = mapper.Map<GetWeatherForecastResponseModel>(weatherForecast);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] PostWeatherForecastRequestModel requestModel, CancellationToken ct)
    {
        if (requestModel == null)
        {
            return BadRequest("Invalid request data.");
        }

        var weatherForecastDto = mapper.Map<CreateWeatherForecastDto>(requestModel);

        await weatherForecastService.Create(weatherForecastDto, ct);

        return CreatedAtAction(null, null);
    }
}

