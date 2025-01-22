using Classroom_Managment.Entity;
using Classroom_Managment.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Classroom_Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomInterface _context;
        public ClassroomController(IClassroomInterface context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Classroom>>> AddProductAsync(string classroomName, int userId)
        {
            if (classroomName == null && userId == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await _context.AddClassroomAsync(classroomName, userId);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Classroom>>> GetClassrooms(int userId)
        {
            if (userId == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await _context.GetClassrooms(userId);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
    }
}
