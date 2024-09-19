using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebdeskEA.Models.DbModel;

public partial class Coa
{
    public int Id { get; set; }

    public string? AccountCode { get; set; }

    public string? Code { get; set; }

    public string? AccountName { get; set; }

    public int? ParentAccountId { get; set; }

    public int? CoatypeId { get; set; }

    public string? Description { get; set; }
    public string? CoaTranType { get; set; }

    public decimal? Debit { get; set; }

    public decimal? Credit { get; set; }

    public bool? Transable { get; set; }

    public int? LevelNo { get; set; }

    public decimal? OpeningBlnc { get; set; }

    public DateTime? OpeningBlncDate { get; set; }

    public int? BusinessCategoryId { get; set; }

    //------ Joined Columns -----
    [NotMapped]
    public string? ParentAccountName { get; set; }
    [NotMapped]
    public string? COATypeName { get; set; }
    [NotMapped]
    public string? BusinessCategoryName { get; set; }
}
