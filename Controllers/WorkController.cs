using Classroom_Managment.Entity;
using Classroom_Managment.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Classroom_Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkInterface _context;
        public WorkController(IWorkInterface context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Work>> GetWork(string classroomId, int teacherId)
        {
            try
            {
                return await _context.GetWork(classroomId, teacherId);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertWrok(string WorkTitle, string WorkDescription, DateTime DueDate, int TeacherID, int ClassroomID)
        {
            if (WorkTitle == null)
            {
                return BadRequest();
            }
            try
            {
                int response = await _context.InsertWrok(WorkTitle, WorkDescription, DueDate, TeacherID, ClassroomID);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWork(int WorkId, string WorkTitle, string WorkDescription, DateTime AssignedDate, DateTime DueDate, int TeacherID, int ClassroomID)
        {
            if (WorkTitle == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _context.UpdateWork(WorkId, WorkTitle, WorkDescription, AssignedDate, DueDate, TeacherID, ClassroomID);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
