using MarketCarsAPI.Controllers.vNeutral;
using MarketCarsLibrary.Data.Interfaces;
using MarketCarsLibrary.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketCarsAPI.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
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
            return BadRequest("Could not get cars");
        }

        return Ok(cars);
    }

    //// GET api/Cars/5
    //[HttpGet("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<ActionResult<CarsModel>> Get(int id)
    //{
    //    var user = await carsData.GetUserById(id);

    //    if (user == null)
    //    {
    //        return BadRequest("Could not get a user, id does not exist");
    //    }

    //    return Ok(user);
    //}

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

    //// PUT api/Cars
    //[HttpPut]
    //[ValidateModel]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<ActionResult<CarsModel>> Put([FromBody] CarsModel CarsModel)
    //{
    //    var user = await carsData.UpdateById(CarsModel);

    //    return Ok(user);
    //}

    //// DELETE api/Cars/5
    //[HttpDelete("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<ActionResult<int>> Delete(int id)
    //{
    //    var user = await carsData.GetUserById(id);

    //    if (user == null)
    //    {
    //        return BadRequest("Id does not exist");
    //    }

    //    await carsData.DeleteById(id);

    //    return Ok();
    //}
}
