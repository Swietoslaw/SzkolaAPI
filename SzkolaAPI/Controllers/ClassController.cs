using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SzkolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private static List<Class> Classes = new List<Class>
            {
              
            };
        private readonly DataContext _context;

        public ClassController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Class>>> Get()
        {
            return Ok(await _context.Class.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> Get(int id)
        {
            var _class = await _context.Class.FindAsync(id);
            if (_class == null)
            {
                return BadRequest("Class not found.");
            }
            return Ok(_class);
        }

        [HttpPost]
        public async Task<ActionResult<List<Class>>> AddClass(Class _class)
        {
            _context.Class.Add(_class);
            await _context.SaveChangesAsync();

            return Ok(await _context.Class.ToListAsync());
        }
        
        [HttpPut]
        public async Task<ActionResult<List<Class>>> UpdateClass(Class request)
        {
            var dbClass = await _context.Class.FindAsync(request.ClassID);
            if (dbClass == null)
            {
                return BadRequest("Class not found.");
            }
            dbClass.ClassName = request.ClassName;

            await _context.SaveChangesAsync();

            return Ok(await _context.Class.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Class>>> Delete(int id)
        {
            var dbClass = await _context.Class.FindAsync(id);
            if (dbClass == null)
            {
                return BadRequest("Class not found.");
            }
            _context.Class.Remove(dbClass);
            await _context.SaveChangesAsync();

            return Ok(await _context.Class.ToListAsync());
        }
    }
}
