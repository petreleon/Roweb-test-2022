using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Roweb_test.Data;
using System;
using System.Linq;

namespace Roweb_test.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Roweb_testContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Roweb_testContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any() || context.Game.Any())
                {
                    return;   // DB has been seeded
                }

                context.Game.AddRange(
                    new Game
                    {
                        Title = "Monument Valley",
                        Creator = "Ustwo",
                        Genre = "casual",
                        ReleaseDate = DateTime.Parse("2014-4-3"),
                        Price = 1.99M
                    }
                );

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}