using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

using Services;

[Route("api/[controller]")]
[ApiController]
public class PeopleController : Controller
{
    private IPeopleService _peopleService;

    public PeopleController([FromKeyedServices("peopleService")]IPeopleService peopleService)
    {
        this._peopleService = peopleService;
    }
    
    [HttpGet("all")] 
    public List<People> GetAll() => Repository.People;

    [HttpGet("{id}")]
    public ActionResult<People> Get(int id)
    {
        var people = Repository.People.FirstOrDefault(p => p.Id == id);
        if (people == null)
        {
            return NotFound();
        }

        return Ok(people);
    }

    [HttpPost]
    public IActionResult Add(People people)
    {
        if (!this._peopleService.Validate(people))
        {
            return BadRequest();
        }
        
        Repository.People.Add(people);

        return NoContent();
    }

    [HttpGet("search/{search}")]
    public List<People> Get(string search)
    {
        return Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();
    }

}

public class Repository
{
    public static List<People> People = new List<People>()
    {
        new People()
        {
            Id = 1, Name = "Peter", Birthdate = new DateTime(1990, 12, 3)
        },
        new People()
        {
            Id = 2, Name = "Estefania", Birthdate = new DateTime(1992, 11, 3)
        },
        new People()
        {
            Id = 3, Name = "Nestor", Birthdate = new DateTime(1986, 9, 13)
        }
    };
}

public class People
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
}