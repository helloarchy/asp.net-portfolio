using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class DbSeed
    {
        public static async Task SeedDatabase(PortfolioContext context)
        {
            context.Database.EnsureCreated();

            /* Super Tappy Packet */
            var name = "Super Tappy Packet";
            await CreateProjectItem(context, name, name.Normalize(),
                true, "A Maltesers themed JavaScript game " +
                      "based on Flappy Bird, built using the Phaser.js engine.",
                "JavaScript", "Phaser.js, Game, " +
                              "Web application, Responsive, Physics");

            /* Workings */
            name = "Workings";
            await CreateProjectItem(context, name, name.Normalize(),
                true, "A web app for a soft furnishings " +
                      "company. Used to calculate fabric requirements and " +
                      "manufacturing dimensions.", "JavaScript",
                "Responsive, Print Friendly, Freelance work, Forms");

            /* Decider */
            name = "Decider";
            await CreateProjectItem(context, name, name.Normalize(),
                true, "A (first attempt) web app for decision " +
                      "making. Add multiple choices and one will be picked at " +
                      "random.", "JavaScript", "Front end, " +
                                               "CSS Flexbox, Responsive");

            /* Java Social Network */
            name = "Java Social Network";
            await CreateProjectItem(context, name, name.Normalize(),
                true, "A simple commandline social network," +
                      " making use of various abstract data types.",
                "Java", "Recursion, Binary Search " +
                        "Trees, Graphs", 
                "/img/thumb/SocialNetwork.png");
            
            /* Decider 2.0 */
            name = "Decider 2.0";
            await CreateProjectItem(context, name, name.Normalize(),
                true, "A (revised) web app for decision making. " +
                      "With shortlists and reject lists to help pin down the " +
                      "desired choice.", "TypeScript",
                "CSS Grid, Web Application, Front End, Responsive");

            /* CT Head */
            name = "CT Head";
            await CreateProjectItem(context, name, name.Normalize(),
                true, "A GUI interface and application for viewing" +
                      " scan data from the Visible Human Project, with image " +
                      "creation and processing on the fly.", "Java",
                "Graphics, Image generating, Image processing, Image " +
                "resizing algorithms, Dataset, JavaFX, FXML, GUI");

            /* Dot Net Core Blog Site */
            name = "ASP.NET Blog";
            await CreateProjectItem(context, name, name.Normalize(),
                true, "A web application blog built using ASP.NET Core " +
                      "2.1 MVC.", "C#",
                ".NET Core, Framework, MVC, Razor Pages, Entity Framework, " +
                "MSSQL Database, Security, Role and Claim based authorisation");

            /* Java Concurrency */
            name = "Java Multithreading & Concurrency";
            await CreateProjectItem(context, name, name.Normalize(),
                true, "A concurrent system where random numbers " +
                      "are generated and sorted into text files by their multiple.",
                "Java", "Multithreading, Concurrency");

            /* Haskell Concurrency */
            name = "Haskell Multithreading & Concurrency";
            await CreateProjectItem(context, name, name.Normalize(),
                true, "A simple trading shop where threads" +
                      " track customers, items, and coins.", 
                "Haskell", "Multithreading, " +
                           "Concurrency, Functional Programming");
        }


        private static async Task CreateProjectItem(PortfolioContext context,
            string name, string nameNormalised, bool isVisible,
            string shortDescription, string programmingLanguages, string keyWords,
            string thumbnailImage = null)
        {
            if (!context.ProjectItem.Any(pi => pi.NameNormalised == nameNormalised))
            {
                await context.SaveChangesAsync();
                context.Add(new ProjectItem
                {
                    ThumbnailImage = thumbnailImage,
                    Name = name,
                    NameNormalised = nameNormalised,
                    ShortDescription = shortDescription,
                    ProgrammingLanguages = programmingLanguages,
                    KeyWords = keyWords,
                    IsVisible = isVisible
                });
            }
        }
    }
}