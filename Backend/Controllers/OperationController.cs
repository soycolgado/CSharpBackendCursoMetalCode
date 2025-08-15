using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        // No es necesario poner que viene del body, al ser post y tener una clase lo
        //     hace automaticamente
        public decimal Add(Numbers numbers, [FromHeader] string Host, [FromHeader(Name = "Content-Length")] string ContentLength)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);
            return numbers.A - numbers.B;
        }
        
        [HttpPut]
        public decimal Edit(decimal a, decimal b)
        {
            return a * b;
        }
        
        [HttpDelete]
        public decimal Delete(decimal a, decimal b)
        {
            return a / b;
        }
    }

    public class Numbers
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
    }
}
