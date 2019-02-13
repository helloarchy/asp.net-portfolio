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
            
            /* SuperTappyPacket */
            var name = "SuperTappyPacket";
            await CreateProjectItem(context, name, name.Normalize(), 
                true, "A Maltesers themed JavaScript game " +
                      "based on FlappyBird, built using the Phaser.js engine.");
            
            /* Workings */
            name = "Workings";
            await CreateProjectItem(context, name, name.Normalize(), 
                true, "A web app for a soft furnishings " +
                      "company. Used to calculate fabric requirements and " +
                      "manufacturing dimensions.");
            
            /* Decider */
            name = "Decider";
            await CreateProjectItem(context, name, name.Normalize(), 
                true, "A (first attempt) web app for decision " +
                      "making. Add multiple choices and one will be picked at " +
                      "random.");
            
            /* Decider 2.0 */
            name = "Decider 2.0";
            await CreateProjectItem(context, name, name.Normalize(), 
                true, "A (revised) web app for decision making. " +
                      "With shortlists and reject lists to help pin down the " +
                      "desired choice.");
            
            /* CT Head */
            name = "CT Head";
            await CreateProjectItem(context, name, name.Normalize(), 
                true, "A GUI interface and application for viewing" +
                      "CT scan data, with image creation and processing on the fly.");
            
            /* Dot Net Core Blog Site */
            name = "DotNet Blog";
            await CreateProjectItem(context, name, name.Normalize(), 
                true, "A web app blog built using ASP.NET Core " +
                      "2.1 MVC.");
            
            /* Java Concurrency */
            name = "Java Concurrency";
            await CreateProjectItem(context, name, name.Normalize(), 
                true, "A concurrent system where random numbers " +
                      "are generated and sorted into text files by their multiple.");
            
            /* Haskell Concurrency */
            name = "Haskell Concurency";
            await CreateProjectItem(context, name, name.Normalize(), 
                true, "A simple trading shop where threads" +
                      " track customers, items, and coins.");
            
        }


        private static async Task CreateProjectItem(PortfolioContext context,
            string name, string nameNormalised, bool isVisible,
            string shortDescription, string thumbnailImage = null)
        {
            /*if (context.ProjectItem.Any(pi => pi.NameNormalised == nameNormalised))*/
            ProjectItem projectItem = await context.ProjectItem
                .FirstOrDefaultAsync(m => m.NameNormalised == nameNormalised);
            if (projectItem == null)
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