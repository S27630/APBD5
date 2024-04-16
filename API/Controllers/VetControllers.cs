using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("Vet")]
public class VetControllers : ControllerBase
{
    private IMockDb _mockDb;

    public VetControllers(IMockDb mockDb)
    {
        _mockDb = mockDb; 
    }
    
    [HttpGet("{animalId}/visits")]
    public IActionResult GetVisitsForAnimal(int animalId)
    {
        var visits = _mockDb.GetVisitsForAnimal(animalId);

        if (visits == null || visits.Count == 0)
        {
            return NotFound("Brak wizyt powiązanych z danym zwierzęciem.");
        }

        return Ok(visits);
    }
    
    [HttpGet]
    public IActionResult GetALL()
    {
        return Ok(_mockDb.GetAllVets());
    }

    [HttpPost("add-visit")]
    public IActionResult AddNewVisit([FromBody] Vet newVisit)
    {
        bool added = _mockDb.AddNewVisit(newVisit);

        if (!added)
        {
            return BadRequest("Nie udało się dodać nowej wizyty. Sprawdź, czy podane zwierzę istnieje.");
        }

        return Created($"vet/{newVisit.date}", newVisit);
    }


}