using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MessageBoardBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("testDb"));

            services.AddCors(options => options.AddPolicy("Cors", builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddMvc();

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                      ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Cors");
            app.UseMvc();

            SeedData(serviceProvider.GetService<ApiContext>());
        }

        public void SeedData(ApiContext context)
        {
            context.Messages.Add(new Models.Message
            {
                Owner = "John",
                Text = "hello"
            });
            context.Messages.Add(new Models.Message
            {
                Owner = "Manuel",
                Text = "wena compare!"
            });

            context.Users.Add(new Models.User {
                Email = "a",
                FirstName = "Tim",
                Password = "a"
            });

            context.SaveChanges();
        }
    }
}
