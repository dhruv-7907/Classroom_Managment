using Classroom_Managment.Entity;

namespace Classroom_Managment.Interface
{
    public interface IWorkInterface
    {
        public Task<List<Work>> GetWork(string classroomId, int teacherId);
        public Task<int> InsertWrok(string WorkTitle, string WorkDescription, DateTime DueDate, int TeacherID, int ClassroomID);

        public Task<int> UpdateWork(int WorkId ,string WorkTitle, string WorkDescription, DateTime AssignedDate, DateTime DueDate, int TeacherID, int ClassroomID);
    }
}
