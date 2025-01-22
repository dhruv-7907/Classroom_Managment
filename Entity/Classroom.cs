using System;
using System.Collections.Generic;

namespace Classroom_Managment.Entity;

public partial class Classroom
{
    public int ClassroomId { get; set; }
    public int test { get; set; }
    public int test1 { get; set; }
    public int test2 { get; set; }
    public string ClassroomName { get; set; } = null!;

    public int TeacherId { get; set; }

    public virtual Teacher Teacher { get; set; } = null!;

    public virtual ICollection<Work> Works { get; set; } = new List<Work>();
}
