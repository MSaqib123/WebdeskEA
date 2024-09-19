using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebdeskEA.Models.DbModel;

public partial class Company
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    public string? Logo { get; set; }
    public string? Address { get; set; }
    [Required]
    public string? Phone { get; set; }
    public string? Description { get; set; }

}
