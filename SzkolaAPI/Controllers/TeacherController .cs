using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SzkolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private static List<Teacher> teachers = new List<Teacher>
            {
              
            };
        private readonly DataContext _context;

        public TeacherController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> Get()
        {
            return Ok(await _context.Teachers.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> Get(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return BadRequest("Teacher not found.");
            }
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult<List<Teacher>>> AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return Ok(await _context.Teachers.ToListAsync());
        }
        
        [HttpPut]
        public async Task<ActionResult<List<Teacher>>> UpdateTeacher(Teacher request)
        {
            var dbTeacher = await _context.Teachers.FindAsync(request.TeacherID);
            if (dbTeacher == null)
            {
                return BadRequest("Teacher not found.");
            }
            dbTeacher.FirstName = request.FirstName;
            dbTeacher.LastName = request.LastName;
            dbTeacher.HiredDate = request.HiredDate;
            dbTeacher.JobTime= request.JobTime;

            await _context.SaveChangesAsync();

            return Ok(await _context.Teachers.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Teacher>>> Delete(int id)
        {
            var dbTeacher = await _context.Teachers.FindAsync(id);
            if (dbTeacher == null)
            {
                return BadRequest("Teacher not found.");
            }
            _context.Teachers.Remove(dbTeacher);
            await _context.SaveChangesAsync();

            return Ok(await _context.Teachers.ToListAsync());
        }
    }
}
