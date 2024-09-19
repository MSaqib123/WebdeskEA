using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class TblMainMenu
{
    public int MenuId { get; set; }

    public int? ModuleId { get; set; }

    public string MenuName { get; set; } = null!;

    public string UrlController { get; set; } = null!;

    public string UrlAction { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int? OrderIndex { get; set; }

    public bool Active { get; set; }
}
