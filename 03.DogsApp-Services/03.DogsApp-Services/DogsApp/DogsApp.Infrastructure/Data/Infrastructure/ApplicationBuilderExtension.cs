﻿using DogsApp.Infrastructure.Data.Domain;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsApp.Infrastructure.Data.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScore = app.ApplicationServices.CreateScope();
            var services = serviceScore.ServiceProvider;
            var data = serviceScore.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedBreeds(data);
            return app;
        }
        private static void SeedBreeds(ApplicationDbContext data)
        {
            if(data.Breeds.Any())
            {
                return;
            }
            data.Breeds.AddRange(new[]
            {
                new Breed {Name="Husky"},
                new Breed {Name="Pinscher"},
                new Breed {Name="Cocer spaniol"},
                new Breed {Name="Dachshund"},
                new Breed {Name="Doberman"},
            });
            data.SaveChanges();
        }
    }
}
