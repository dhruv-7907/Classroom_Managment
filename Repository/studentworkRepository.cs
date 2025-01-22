using Classroom_Managment.Entity;
using Classroom_Managment.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Classroom_Managment.Repository
{
    public class studentworkRepository : IstudentWorkInterface
    {
        private readonly ClassroomContext _context;
        public studentworkRepository(ClassroomContext context)
        {
            _context = context;
        }
        public async Task<List<Work>> GetStudentWork(int classroomId)
        {
            var classroomIdParam = new SqlParameter("@classroomId", classroomId);
            return await _context.Works
               .FromSqlRaw<Work>(@" exec SP_GetstudentWork @classroomId", classroomIdParam)
               .ToListAsync();
        }
    }
}
