using Asp.Versioning;
using MarketCarsAPI.Models;
using MarketCarsLibrary.Data.Interfaces;
using MarketCarsLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketCarsAPI.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class CarsController : ControllerBase
{
    private ICarsData carsData { get; set; }
    public CarsController(ICarsData carsData)
    {
        this.carsData = carsData;
    }

    // GET api/Cars
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<CarsModel>>> Get()
    {
        var cars = await carsData.GetAll();

        if (cars == null)
        {
            return BadRequest("Could not get all cars");
        }

        return Ok(cars);
    }

    //// GET api/Cars/5
    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<CarsModel>>> Get(int userId)
    {
        var cars = await carsData.GetAllByUserId(userId);

        if (cars == null)
        {
            return BadRequest("Could not get all cars of the owner");
        }

        return Ok(cars);
    }

    //// GET api/Cars/5/3
    [HttpGet("{userId}/{carId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarsModel>> Get(int userId, int carId)
    {
        var car = await carsData.GetAllByUserAndCarId(userId, carId);

        if (car == null)
        {
            return BadRequest("Could not get specific car of the owner");
        }

        return Ok(car);
    }

    // POST api/Cars
    [HttpPost]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarsModel>> Post([FromBody] CarsModel CarsModel)
    {
        var car = await carsData.Create(CarsModel);

        if (car == null)
        {
            return BadRequest("Could not create a car");
        }

        return Ok(car);
    }

    // PUT api/Cars
    [HttpPut]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarsModel>> Put([FromBody] CarsModel CarsModel)
    {
        var user = await carsData.UpdateById(CarsModel);

        return Ok(user);
    }

    // DELETE api/Cars/5
    [HttpDelete("{carId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<int>> Delete(int carId)
    {
        await carsData.DeleteById(carId);

        return Ok();
    }
}
