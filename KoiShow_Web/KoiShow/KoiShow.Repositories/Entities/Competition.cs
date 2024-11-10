using System;
using System.Collections.Generic;

namespace KoiShow.Repositories.Entities;

public partial class Competition
{
    public int CompetitionId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Koishowparticipation> Koishowparticipations { get; set; } = new List<Koishowparticipation>();
}
