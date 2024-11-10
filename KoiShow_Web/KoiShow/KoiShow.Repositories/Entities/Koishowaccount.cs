using System;
using System.Collections.Generic;

namespace KoiShow.Repositories.Entities;

public partial class Koishowaccount
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
}
