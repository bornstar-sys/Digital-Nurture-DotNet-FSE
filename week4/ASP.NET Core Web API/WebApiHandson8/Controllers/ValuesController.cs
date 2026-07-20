using Microsoft.AspNetCore.Mvc;

namespace WebApiHandson8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        static List<string> values = new()
        {
            "Value1",
            "Value2",
            "Value3"
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id >= values.Count)
                return NotFound();

            return Ok(values[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            values.Add(value);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id >= values.Count)
                return NotFound();

            values[id] = value;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id >= values.Count)
                return NotFound();

            values.RemoveAt(id);

            return Ok();
        }
    }
}