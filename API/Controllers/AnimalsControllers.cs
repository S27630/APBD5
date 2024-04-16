using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("Animals")]
public class AnimalsControllers : ControllerBase
{
    
    private IMockDb _mockDb;

    public AnimalsControllers(IMockDb mockDb)
    {
        _mockDb = mockDb; 
    }
    
    [HttpGet]
    public IActionResult GetALL()
    {
        return Ok(_mockDb.GetAllAnimals());
    }
   
    [HttpGet("{id}")]
    public IActionResult GetDetails(int id)
    {
        var animal = _mockDb.PickAnimal(id);
        if (animal is null)
        {
            return NotFound();
        }
        return Ok(animal);

    }

    [HttpPost]
    public IActionResult Add(Animal animal)
    {
        _mockDb.AddAnimal(animal);
        return Created($"animal/{animal.Id}", animal);

    }
    
    [HttpPut("{id, new Animal}")]
    public IActionResult Replace(int id, Animal animal)
    {
        if(_mockDb.EditAnimal(id, animal) is null)return NotFound();
        return Ok();

    }
    
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        if(_mockDb.RemoveAnimal(id) is null) return NotFound();
        return NoContent();

    }
}