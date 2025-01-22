using Classroom_Managment.Entity;
using Classroom_Managment.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Classroom_Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginInterface _context;
        public LoginController(ILoginInterface context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<dynamic>> GetTeacherByIdAsync(string Type, string Email)
            {
            try
            {
                var response = await _context.GetTeacherByIdAsync(Type,Email);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
