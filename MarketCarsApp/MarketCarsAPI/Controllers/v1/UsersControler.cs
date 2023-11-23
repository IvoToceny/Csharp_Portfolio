using MarketCarsAPI.Controllers.vNeutral;
using MarketCarsLibrary.Data;
using MarketCarsLibrary.Data.Interfaces;
using MarketCarsLibrary.Db;
using MarketCarsLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketCarsAPI.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
public class UsersControler : ControllerBase
{
    private IUsersData usersData { get; set; }
    public UsersControler(IUsersData usersData)
    {
        this.usersData = usersData;
    }

    // GET api/Users/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UsersModel>> Get(int id)
    {
        var user = await usersData.GetUserById(id);

        if (user == null)
        {
            return BadRequest("Could not get a user, id does not exist");
        }

        return Ok(user);
    }

    // POST api/Users
    [HttpPost]
    [ValidateModel]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UsersModel>> Post([FromBody] UsersModel usersModel)
    {
        var user = await usersData.Create(usersModel);

        if(user == null)
        {
            return BadRequest("Could not create a user");
        }

        return Ok(user);
    }

    // PUT api/Users/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] UsersModel usersModel)
    //{
    //}

    // DELETE api/Users/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Delete(int id)
    {
        var user = await usersData.GetUserById(id);

        if (user == null)
        {
            return BadRequest("Id does not exist");
        }

        await usersData.DeleteById(id);

        return Ok();
    }
}
