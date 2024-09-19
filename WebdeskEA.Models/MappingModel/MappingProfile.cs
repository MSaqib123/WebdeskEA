using AutoMapper;
using WebdeskEA.Models.DbModel;
using WebdeskEA.Models.ExternalModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Models.MappingModel;

// Profile for Select Operations
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ModuleDto, Module>().ReverseMap();
        CreateMap<UserRightDto, UserRight>().ReverseMap();
        CreateMap<COATypeDto, Coatype>().ReverseMap();
        CreateMap<COADto, Coa>().ReverseMap();
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<CompanyDto, Company>().ReverseMap();
        CreateMap<CompanyBusinessCategoryDto, BusinessCategory>().ReverseMap();
        CreateMap<CompanyUserDto, CompanyUser>().ReverseMap();
        CreateMap<ErrorLogDto, ErrorLog>().ReverseMap();

        CreateMap<CompanyUserDto, CompanyUser>().ReverseMap();


        //____ Identity ____
        CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
    }

}
