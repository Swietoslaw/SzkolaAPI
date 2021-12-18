using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SzkolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>
            {
              
            };
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.Students.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return BadRequest("Student not found.");
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }
        
        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student request)
        {
            var dbStudent = await _context.Students.FindAsync(request.StudentID);
            if (dbStudent == null)
            {
                return BadRequest("Student not found.");
            }
            dbStudent.FirstName = request.FirstName;
            dbStudent.LastName = request.LastName;
            dbStudent.BirthDate = request.BirthDate;
            dbStudent.ClassID = request.ClassID;

            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> Delete(int id)
        {
            var dbStudent = await _context.Students.FindAsync(id);
            if (dbStudent == null)
            {
                return BadRequest("Student not found.");
            }
            _context.Students.Remove(dbStudent);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }
    }
}
