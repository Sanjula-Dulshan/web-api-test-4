using API.Models.Streams;
using API.Models.Student;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public ActionResult<object> Post(Student student)
        {
            var result = studentService.Create(student);
            return Ok(new { result });
        }

    }
}
