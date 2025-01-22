using Classroom_Managment.Entity;
using Classroom_Managment.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Classroom_Managment.Repository
{
    public class LoginRepository : ILoginInterface
    {
        private readonly ClassroomContext _context;
        public LoginRepository(ClassroomContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<dynamic>> GetTeacherByIdAsync(string Type , string Email)
        {
            var typeParam = new SqlParameter("@Type", Type);
            var emailParam = new SqlParameter("@Email", Email);

            if (Type == "Teacher")
            {
                var teacherDetails = await _context.Teachers
                    .FromSqlRaw(@"EXEC Sp_getLogin @Type, @Email", typeParam, emailParam)
                    .ToListAsync<dynamic>();
                return teacherDetails;
            }
            else if (Type == "Student")
            {
                var studentDetails = await _context.Students
                    .FromSqlRaw(@"EXEC Sp_getLogin @Type, @Email", typeParam, emailParam)
                    .ToListAsync<dynamic>();
                return studentDetails;
            }

            return Enumerable.Empty<dynamic>();

        }
    }
}
