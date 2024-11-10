using System;
using System.Collections.Generic;

namespace KoiShow.Repositories.Entities;

public partial class Koifish
{
    public int KoiId { get; set; }

    public int? OwnerId { get; set; }

    public string Name { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public int? Age { get; set; }

    public float? Size { get; set; }

    public int? CategoryId { get; set; }

    public virtual Koicategory? Category { get; set; }

    public virtual ICollection<Koishowparticipation> Koishowparticipations { get; set; } = new List<Koishowparticipation>();
}
