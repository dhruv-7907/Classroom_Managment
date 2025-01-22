using Classroom_Managment.Entity;

namespace Classroom_Managment.Interface
{
    public interface IstudentWorkInterface
    {
        public Task<List<Work>> GetStudentWork(int classroomId);
        
        
    }
}
