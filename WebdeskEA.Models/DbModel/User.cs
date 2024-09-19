using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CompanyId { get; set; }
}
