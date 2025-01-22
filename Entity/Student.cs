using System;
using System.Collections.Generic;

namespace Classroom_Managment.Entity;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? ClassroomId { get; set; }

    public virtual ICollection<StudentWork> StudentWorks { get; set; } = new List<StudentWork>();
}
