using Classroom_Managment.Entity;
using Classroom_Managment.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Classroom_Managment.Repository
{

    public class WorkRepository : IWorkInterface
    {
        private readonly ClassroomContext _context;
        public WorkRepository(ClassroomContext context)
        {
            _context = context;
        }

        public async Task<List<Work>> GetWork(string classroomId,int teacherId)
        {
            var classroomIdParam = new SqlParameter("@classroomId", classroomId);
            var teacherIdParam = new SqlParameter("@teacherId", teacherId);
            return await _context.Works
               .FromSqlRaw<Work>(@" exec SP_GetWork @classroomId,@teacherId", classroomIdParam, teacherIdParam)
               .ToListAsync();
        }

        public async Task<int> InsertWrok(string WorkTitle, string WorkDescription, DateTime DueDate, int TeacherID, int ClassroomID)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@WorkTitle", WorkTitle));
            parameter.Add(new SqlParameter("@WorkDescription", WorkDescription));
            parameter.Add(new SqlParameter("@DueDate", DueDate));
            parameter.Add(new SqlParameter("@TeacherID", TeacherID));
            parameter.Add(new SqlParameter("@ClassroomID", ClassroomID));
            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec SP_InsertWork @WorkTitle, @WorkDescription, @DueDate, @TeacherID ,@ClassroomID", parameter.ToArray()));
            return result;
        }

        public async Task<int> UpdateWork(int WorkId, string WorkTitle, string WorkDescription, DateTime AssignedDate, DateTime DueDate, int TeacherID, int ClassroomID)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@WorkId", WorkId));
            parameter.Add(new SqlParameter("@WorkTitle", WorkTitle));
            parameter.Add(new SqlParameter("@WorkDescription", WorkDescription));
            parameter.Add(new SqlParameter("@AssignedDate", AssignedDate));
            parameter.Add(new SqlParameter("@DueDate", DueDate));
            parameter.Add(new SqlParameter("@TeacherID", TeacherID));
            parameter.Add(new SqlParameter("@ClassroomID", ClassroomID));
            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec SP_UpdateWork @WorkId, @WorkTitle, @WorkDescription, @AssignedDate, @DueDate ,@TeacherID,@ClassroomID", parameter.ToArray()));
            return result;
        }
    }
}
