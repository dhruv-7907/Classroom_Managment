using Classroom_Managment.Entity;
using Classroom_Managment.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Classroom_Managment.Repository
{
    public class ClassroomRepository : IClassroomInterface
    {
        private readonly ClassroomContext _context;
        public ClassroomRepository(ClassroomContext context)
        {
            _context = context;
        }
        public async Task<List<Classroom>> AddClassroomAsync(string classroomName, int userId)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@ClassroomName", classroomName));
            parameter.Add(new SqlParameter("@TeacherId", userId));

            var result = await _context.Classrooms
            .FromSqlRaw(@"exec sp_CreateClassRoom @ClassroomName, @TeacherId", parameter.ToArray())
            .ToListAsync();
             return result;

        }

        public  async Task<List<Classroom>> GetClassrooms(int userId)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TeacherId", userId));
            var result = await _context.Classrooms
             .FromSqlRaw(@"SELECT * FROM Classroom WHERE TeacherId = @TeacherId", parameter.ToArray())
            .ToListAsync();
            return result;
        }
    }


}
