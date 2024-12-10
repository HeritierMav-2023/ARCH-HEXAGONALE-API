using Microsoft.AspNetCore.Mvc;
using SGE.HexagonalArchiPattern.Core.Entities;
using SGE.HexagonalArchiPattern.Core.Ports.Driving;

namespace SGE.HexagonalArchiPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //1- Propriétes
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        //2-Constructeur
        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _logger = logger;
            _studentService = studentService;
        }

        #region Verbs Methods

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int Id)
        {
            var student = await _studentService.GetByIdAsync(Id);

            return Ok(student);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();

            return Ok(students);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] Student student)
        {
            await _studentService.AddAsync(student);
            _logger.LogInformation("Student {StudentName} added", student.FirstName);

            return Ok(student);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _studentService.DeleteAsync(Id);
            _logger.LogInformation("Student {StudentId} was deleted", Id);

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Student student)
        {
            var checkStudent =  await _studentService.GetByIdAsync(student.Id);
            if (checkStudent == null)
            {
                return NotFound(checkStudent);
            }
            await _studentService.UpdateAsync(checkStudent);
            _logger.LogInformation("Student {Student} updated", checkStudent.FirstName);
            return NoContent();
        }
        #endregion
    }
}
