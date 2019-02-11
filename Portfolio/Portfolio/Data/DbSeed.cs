using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Portfolio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Data
{
    public class DbSeed
    {
        public static async Task SeedDatabase(PortfolioContext context)
        {
            context.Database.EnsureCreated();
            const string name = "SuperTappyPacket";
            string nameNormalised = name.Normalize();
            await CreateProjectItem(context, name, nameNormalised, true,
                "A Maltesers themed JavaScript game based on FlappyBird");
        }


        private static async Task CreateProjectItem(PortfolioContext context,
            string name, string nameNormalised, bool isVisible,
            string shortDescription, string thumbnailImage = null)
        {
            if (!context.ProjectItem.Any(pi => pi.NameNormalised == nameNormalised))
            {
                context.Add(new ProjectItem
                {
                    Name = name,
                    NameNormalised = nameNormalised,
                    IsVisible = isVisible,
                    ShortDescription = shortDescription,
                    ThumbnailImage = thumbnailImage
                });
                await context.SaveChangesAsync();
            }
        }
    }
}