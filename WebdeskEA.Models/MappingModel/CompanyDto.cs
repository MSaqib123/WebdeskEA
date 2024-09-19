using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Models.MappingModel;

public class CompanyDto
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
