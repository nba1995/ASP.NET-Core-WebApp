using System;
using System.Collections.Generic;

namespace Corsi.Models.Entities;

public partial class Course
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImagePath { get; set; }

    public string Author { get; set; } = null!;

    public string? Email { get; set; }

    public double Rating { get; set; }

    public byte[] FullPriceAmount { get; set; } = null!;

    public string FullPriceCurrency { get; set; } = null!;

    public byte[] CurrentPriceAmount { get; set; } = null!;

    public string CurrentPriceCurrency { get; set; } = null!;

    public byte[]? RowVersion { get; set; }

    public virtual ICollection<Lesson> Lessons { get; } = new List<Lesson>();
}
