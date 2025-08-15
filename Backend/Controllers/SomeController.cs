using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

using System.Diagnostics;

[Route("api/[controller]")]
[ApiController]
public class SomeController : Controller
{
    [HttpGet("sync")]
    public IActionResult GetSync()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Thread.Sleep(1000);
        Console.WriteLine("Conexion a la base de datos terminada");
        Thread.Sleep(1000);
        Console.WriteLine("Envio de mail terminado");
        Console.WriteLine("Todos los procesos terminados");
        stopwatch.Stop();
        return Ok(stopwatch.Elapsed);
    }

    [HttpGet("async")]
    public async Task<IActionResult> GetAsync()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        var task1 = new Task<int>(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("Conexion a la base de datos terminada");
            return 1;
        });
        var task2 = new Task<int>(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("Envio de mail terminado");
            return 1;
        });
        task1.Start();
        task2.Start();
        Console.WriteLine("Hago otra cosa");
        var result1 = await task1;
        var result2 = await task2;
        Console.WriteLine("Todo ha terminado");
        stopwatch.Stop();
        return Ok($"{result1} {result2} {stopwatch.Elapsed}");
    }
}