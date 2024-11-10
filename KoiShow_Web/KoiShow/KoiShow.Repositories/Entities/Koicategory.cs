using System;
using System.Collections.Generic;

namespace KoiShow.Repositories.Entities;

public partial class Koicategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Koifish> Koifishes { get; set; } = new List<Koifish>();
}
