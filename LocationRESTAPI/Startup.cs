using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationRESTAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LocationRESTAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            // Registered DB contexts
            services.AddDbContext<UserLocationContext>(options => options.UseInMemoryDatabase("UserLocations"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Populate in memory DB with mock data
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<UserLocationContext>();
            LoadMockData(context);
        }

        private static void LoadMockData(UserLocationContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.Parse("f53ed0af-cc06-4120-bce4-97ce4f4a00e5"),
                    FullName = "John Johnson",
                    Email = "john.johnson@locations.co.uk"
                },
                new User
                {
                    Id = Guid.Parse("e3ce686a-ff0b-4eac-a931-693106a257c6"),
                    FullName = "Mark Smith",
                    Email = "mark.smith@locations.co.uk"
                },
                new User
                {
                    Id = Guid.Parse("63677671-3488-45e0-bbe6-92c9d1d8f965"),
                    FullName = "Jake Jackson",
                    Email = "jake.jackson@locations.co.uk"
                },
            };

            context.AddRange(users.ToArray());
            context.SaveChanges();
        }
    }
}
