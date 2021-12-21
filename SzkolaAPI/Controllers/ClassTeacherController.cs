using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SzkolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassTeacherController : ControllerBase
    {
        private static List<ClassTeacher> ClassTeacher = new List<ClassTeacher>
            {
              
            };
        private readonly DataContext _context;

        public ClassTeacherController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClassTeacher>>> Get()
        {
            return Ok(await _context.ClassTeacher.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassTeacher>> Get(int id)
        {
            var _classTeacher = await _context.ClassTeacher.FindAsync(id);
            if (_classTeacher == null)
            {
                return BadRequest("Class not found.");
            }
            return Ok(_classTeacher);
        }

        [HttpPost]
        public async Task<ActionResult<List<ClassTeacher>>> AddClassTeacher(ClassTeacher _classTeacher)
        {
            _context.ClassTeacher.Add(_classTeacher);
            await _context.SaveChangesAsync();

            return Ok(await _context.ClassTeacher.ToListAsync());
        }
        
        [HttpPut]
        public async Task<ActionResult<List<ClassTeacher>>> UpdateClassTeacher(ClassTeacher request)
        {
            var dbClassroom = await _context.ClassTeacher.FindAsync(request.ID);
            if (dbClassroom == null)
            {
                return BadRequest("Class not found.");
            }
            dbClassroom.ClassID = request.ClassID;
            dbClassroom.TeacherID = request.TeacherID;

            await _context.SaveChangesAsync();

            return Ok(await _context.ClassTeacher.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ClassTeacher>>> Delete(int id)
        {
            var dbClassroom = await _context.ClassTeacher.FindAsync(id);
            if (dbClassroom == null)
            {
                return BadRequest("Class not found.");
            }
            _context.ClassTeacher.Remove(dbClassroom);
            await _context.SaveChangesAsync();

            return Ok(await _context.ClassTeacher.ToListAsync());
        }
    }
}
