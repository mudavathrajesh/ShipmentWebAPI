using Microsoft.AspNetCore.Mvc;
using ShipmentWebAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace ShipmentWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
  
  private readonly TestDbContext _dbContext;
    private readonly ILogger<PersonController> _logger;

    public PersonController(TestDbContext dbCotext, ILogger<PersonController> logger)
    {
        _dbContext = dbCotext;
          _logger = logger;
    }

    [HttpGet("GetPersons")]
    public IActionResult Get()
    {
     List<Person> persons = _dbContext.Persons.FromSql($"GetPersons").ToList();
     return Ok(persons);
    }
}
