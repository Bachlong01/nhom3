using System;
using System.Collections.Generic;

namespace KoiShow.Repositories.Entities;

public partial class Koishowparticipation
{
    public int ParticipationId { get; set; }

    public int? CompetitionId { get; set; }

    public int? KoiId { get; set; }

    public string? Status { get; set; }

    public virtual Competition? Competition { get; set; }

    public virtual Koifish? Koi { get; set; }
}
