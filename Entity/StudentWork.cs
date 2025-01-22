using System;
using System.Collections.Generic;

namespace Classroom_Managment.Entity;

public partial class StudentWork
{
    public int StudentWorkId { get; set; }

    public int StudentId { get; set; }

    public int WorkId { get; set; }

    public string CompletionStatus { get; set; } = null!;

    public DateOnly SubmittedDate { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Work Work { get; set; } = null!;
}
