using WebdeskEA.DataAccess;
using WebdeskEA.Models.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.DataAccess.Data.DataSeeder
{
    public static class CompanySeeder
    {
        public static void Seed(WebdeskEADBContext context)
        {
            context.Database.ExecuteSqlRaw("DELETE FROM Company");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Company', RESEED, 0)");

            context.Companies.AddRange(
                 new Company
                 {
                     Name = "FashionHub"
                 },
                 new Company
                 {
                     Name = "Trendsetters"
                 },
                 new Company
                 {
                     Name = "GarmentGalaxy"
                 },
                 new Company
                 {
                     Name = "ApparelPros"
                 },
                 new Company
                 {
                     Name = "StyleSage"
                 }
             );
            context.SaveChanges();

        }
    }
}
