using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Transactions.Data;

namespace Transactions
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transactions", Version = "v1" });
            });
            services.AddDbContext<TransactionsContext>(options =>
                    //options.UseMySql("Server=db;DataBase=transactions;Uid=root;Pwd=toor123", builder => builder.MigrationsAssembly("Transactions")));
                    options.UseMySql("Server=172.21.0.2;Port=3306;DataBase=transactions;Uid=root;Pwd=toor123", builder => builder.MigrationsAssembly("Transactions")));
                    //options.UseMySql(Configuration.GetConnectionString("TransactionsContext"), builder => builder.MigrationsAssembly("Transactions")));
            services.AddScoped<TransactionsContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transactions v1"));
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<TransactionsContext>())
                {
                    context.Database.Migrate();
                }
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
