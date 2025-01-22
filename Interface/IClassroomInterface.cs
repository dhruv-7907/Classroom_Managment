using Classroom_Managment.Entity;

namespace Classroom_Managment.Interface
{
    public interface IClassroomInterface
    {
        public Task<List<Classroom>> AddClassroomAsync(string classroomName, int userId);
        public Task<List<Classroom>> GetClassrooms(int userId);
    }
}
