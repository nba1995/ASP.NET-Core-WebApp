using System;
using System.Collections.Generic;

namespace Corsi.Models.Entities;

public partial class Lesson
{
    public long Id { get; set; }

    public long CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Duration { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
