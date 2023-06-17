using Microsoft.AspNetCore.Mvc;
using ShipmentWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace ShipmentWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipmentController : ControllerBase
{
 private readonly ShipmentExerciseDbContext _dbContext;
    private readonly ILogger<ShipmentController> _logger;

    public ShipmentController(ShipmentExerciseDbContext dbContext, ILogger<ShipmentController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [HttpGet("GetShipmentLatestStatus")]
    public IActionResult GetShipmentStatus([Required]DateTime fromDate, [Required]DateTime? toDate)
    {
        if(toDate is null){
            toDate =  fromDate;
        }
       var fromParam = new SqlParameter("@fromdate", fromDate.ToString("yyyy-MM-dd"));
       var toParam = new SqlParameter("@todate", toDate?.ToString("yyyy-MM-dd"));

       var result = _dbContext.ShipmentTestResultss.FromSql($"EXEC procGetShipmentLatestStatusByDateRange {fromParam}, {toParam}").ToList();
       return Ok(result);
    }
}
