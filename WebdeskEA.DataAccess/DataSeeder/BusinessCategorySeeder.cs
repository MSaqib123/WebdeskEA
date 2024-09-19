using WebdeskEA.DataAccess;
using WebdeskEA.Models.DbModel;
using WebdeskEA.Models.ExternalModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public static class BusinessCategorySeeder
{
    public static void Seed(WebdeskEADBContext context)
    {
        // Delete existing records
        context.Database.ExecuteSqlRaw("DELETE FROM BusinessCategory");

        // Reset identity column to ensure the first new Id will be 1
        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('BusinessCategory', RESEED, 1)");

        // Retrieve the companies from the database
        var companies = context.Companies.ToList();

        // Seed BusinessCategories for each company
        foreach (var company in companies)
        {
            switch (company.Name)
            {
                case "FashionHub":
                    context.BusinessCategories.AddRange(
                        new BusinessCategory { Name = "Fashion Accessories", CompanyId = company.Id },
                        new BusinessCategory { Name = "Apparel", CompanyId = company.Id }
                    );
                    break;
                case "Trendsetters":
                    context.BusinessCategories.AddRange(
                        new BusinessCategory { Name = "Trendy Clothing", CompanyId = company.Id },
                        new BusinessCategory { Name = "Footwear", CompanyId = company.Id }
                    );
                    break;
                case "GarmentGalaxy":
                    context.BusinessCategories.AddRange(
                        new BusinessCategory { Name = "Casual Wear", CompanyId = company.Id },
                        new BusinessCategory { Name = "Formal Wear", CompanyId = company.Id }
                    );
                    break;
                case "ApparelPros":
                    context.BusinessCategories.AddRange(
                        new BusinessCategory { Name = "Outdoor Gear", CompanyId = company.Id },
                        new BusinessCategory { Name = "Sports Apparel", CompanyId = company.Id }
                    );
                    break;
                case "StyleSage":
                    context.BusinessCategories.AddRange(
                        new BusinessCategory { Name = "Luxury Fashion", CompanyId = company.Id },
                        new BusinessCategory { Name = "Evening Wear", CompanyId = company.Id }
                    );
                    break;
                default:
                    // Handle any unexpected company names
                    break;
            }
        }

        context.SaveChanges();
    }
}
