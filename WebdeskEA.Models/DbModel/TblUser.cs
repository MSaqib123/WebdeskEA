using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class TblUser
{
    public int Id { get; set; }

    public string LoginId { get; set; } = null!;

    public string? LoginName { get; set; }

    public string? LoginEmail { get; set; }

    public string? LoginPhone { get; set; }

    public int RoleId { get; set; }

    public int? DepartmentId { get; set; }

    public string LoginPassword { get; set; } = null!;

    public bool? LoginEnabled { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreateAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? PasswordChangeDate { get; set; }

    public string? LastModifiedUserEmail { get; set; }
}
