using System;
using System.Collections.Generic;

namespace Classroom_Managment.Entity;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string TeacherName { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

    public virtual ICollection<Work> Works { get; set; } = new List<Work>();
}
