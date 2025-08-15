using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

using Services;

[Route("api/[controller]")]
[ApiController]
public class RandomController : Controller
{
    private IRandomService _randomServiceSingleton;
    private IRandomService _randomServiceScoped;
    private IRandomService _randomServiceTransient;
    
    private IRandomService _randomService2Singleton;
    private IRandomService _randomService2Scoped;
    private IRandomService _randomService2Transient;

    public RandomController(
        [FromKeyedServices("randomSingleton")] IRandomService randomServiceSingleton,
        [FromKeyedServices("randomScoped")] IRandomService randomServiceScoped,
        [FromKeyedServices("randomTransient")] IRandomService randomServiceTransient,
        [FromKeyedServices("randomSingleton")] IRandomService randomService2Singleton,
        [FromKeyedServices("randomScoped")] IRandomService randomService2Scoped,
        [FromKeyedServices("randomTransient")] IRandomService randomService2Transient)
    {
        this._randomServiceSingleton = randomServiceSingleton;
        this._randomServiceScoped = randomServiceScoped;
        this._randomServiceTransient = randomServiceTransient;
        
        this._randomService2Singleton = randomService2Singleton;
        this._randomService2Scoped = randomService2Scoped;
        this._randomService2Transient = randomService2Transient;
    }

    [HttpGet]
    public ActionResult<Dictionary<string, int>> Get()
    {
        var result = new Dictionary<string, int>();
        result.Add("randomSingleton 1", _randomServiceSingleton.Value);
        result.Add("randomScoped 1", _randomServiceScoped.Value);
        result.Add("randomTransient 1", _randomServiceTransient.Value);
        result.Add("randomSingleton 2", _randomService2Singleton.Value);
        result.Add("randomScoped 2", _randomService2Scoped.Value);
        result.Add("randomTransient 2", _randomService2Transient.Value);
        return result;
    }
    
}