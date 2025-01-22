using Classroom_Managment.Entity;

namespace Classroom_Managment.Interface
{
    public interface ILoginInterface
    {
        public Task<IEnumerable<dynamic>> GetTeacherByIdAsync(string Type, string Email);
    }
}
