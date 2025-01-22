using System;
using System.Collections.Generic;

namespace Classroom_Managment.Entity;

public partial class Work
{
    public int WorkId { get; set; }

    public string WorkTitle { get; set; } = null!;

    public string WorkDescription { get; set; } = null!;

    public DateOnly AssignedDate { get; set; }

    public DateTime DueDate { get; set; }

    public int TeacherId { get; set; }

    public int ClassroomId { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual ICollection<StudentWork> StudentWorks { get; set; } = new List<StudentWork>();

    public virtual Teacher Teacher { get; set; } = null!;
}
