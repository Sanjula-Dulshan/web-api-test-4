using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamController : ControllerBase
    {
        private readonly IStreamService streamService;
        public StreamController(IStreamService streamService)
        {
            this.streamService = streamService;

        }

        // GET: api/<StreamController>
        [HttpGet]
        public ActionResult<List<Streams>> Get()
        {
            return streamService.Get();

        }

        [HttpPost]
        public ActionResult<Streams> Post([FromBody] Streams stream) {
            var result = streamService.Create(stream);
            return Ok(result);
        }


    }
}
