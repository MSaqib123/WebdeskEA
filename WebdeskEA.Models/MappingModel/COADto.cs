using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Models.MappingModel
{
    public class COADto
    {

        public COADto()
        {
            CoatypeDtoList = new List<COATypeDto>();
            COADtoList = new List<COADto>();
            BusinessCategoryList = new List<CompanyBusinessCategoryDto>();
        }

        public int Id { get; set; }

        public string? AccountCode { get; set; }

        public string? Code { get; set; }
        [Required]
        public string? AccountName { get; set; }
        public int? ParentAccountId { get; set; }
        [Required]
        public int? CoatypeId { get; set; }
        [Required]
        public string? CoaTranType { get; set; }
        public string? Description { get; set; }

        public decimal? Debit { get; set; }

        public decimal? Credit { get; set; }

        public bool? Transable { get; set; } = false;

        public int? LevelNo { get; set; }
        [ValidateNever]
        public decimal? OpeningBlnc { get; set; }
        [ValidateNever]
        public DateTime? OpeningBlncDate { get; set; }

        public int? BusinessCategoryId { get; set; }

        //__________ Note Mapped __________
        [ValidateNever]
        public IEnumerable<COATypeDto> CoatypeDtoList { get; set; }
        [ValidateNever]
        public IEnumerable<COADto> COADtoList { get; set; }
        [ValidateNever]
        public IEnumerable<CompanyBusinessCategoryDto> BusinessCategoryList{ get; set; }
        [ValidateNever]
        public SelectList CoaTransactionTypeList { get; set; }


        //------ Joined Columns -----
        [ValidateNever]
        public string? ParentAccountName { get; set; }
        [ValidateNever]
        public string? COATypeName { get; set; }
        [ValidateNever]
        public string? BusinessCategoryName { get; set; }

    }
}
