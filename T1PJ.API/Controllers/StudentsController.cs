using Microsoft.AspNetCore.Mvc;
using T1PJ.Domain.Entity;
using T1PJ.Domain.Model.Paginations;
using T1PJ.Domain.Model.Students;
using T1PJ.Core.Services.Students;

namespace T1PJ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/Details/{id}")]
        public async Task<ActionResult<Student>> Details(int id)
        {
            var result = await _studentService.GetStudentById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("/Delete/{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            try
            {
                await _studentService.Delete(id);
                return Ok();
            } catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
