using Classroom_Managment.Entity;
using Classroom_Managment.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Classroom_Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentworkController : ControllerBase
    {
        private readonly IstudentWorkInterface _context;
        public studentworkController(IstudentWorkInterface context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Work>> GetStudentWork(int classroomId)
        {
            try
            {
                return await _context.GetStudentWork(classroomId);
            }
            catch
            {
                throw;
            }
        }
    }
}
