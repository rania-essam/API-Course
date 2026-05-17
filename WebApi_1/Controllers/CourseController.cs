using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        ApiCrsDbContext _context;
        public CourseController(ApiCrsDbContext context)
        {
            _context = context;
        }
        // routing is based on ( url + verb )

        //get all
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Courses.ToList());
        }
        //get by id

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            Course c = _context.Courses.Find(id);

            if (c == null) return NotFound();//404
            else return Ok(c);//200
        }
        //get by name
        [HttpGet("/api/GetByName/{name}")]

        public IActionResult GetByName(string name)
        {
            Course c = _context.Courses.FirstOrDefault(c => c.CrsName == name);

            if (c == null) return NotFound();//404
            else return Ok(c);//200
        }
        //add
        [HttpPost]
        public IActionResult AddCourse (Course c)
        {
            if (c == null) return BadRequest();
           
                _context.Courses.Add(c);
                _context.SaveChanges();
                return CreatedAtAction("GetByID", new { id = c.Id }, c);
            
        }
        //update
        [HttpPut]
        public IActionResult UpdateCourse(int id,Course c)
        {
            if(id != c.Id || c == null) return BadRequest();
            _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        //delete
        [HttpDelete]

        public IActionResult DeleteCourse(int id)
        {
            Course c = _context.Courses.Find(id);
            if (c == null) return BadRequest();

            _context.Courses.Remove(c);
            _context.SaveChanges();

            return Ok("Deleted Successfully ");
        }

    }
}
