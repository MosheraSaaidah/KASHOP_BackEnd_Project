
using KAShop.BLL.Service;
using KAShop.DAL.Data;
using KAShop.DAL.Repository;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace KAShop.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            // Add Scoped Services
            builder.Services.AddDbContext<ApplicationDbContext>(option =>

                    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

                );
            // Resources

            builder.Services.AddLocalization(options => options.ResourcesPath = "");

            const string defaultCulture = "en";
            var supportedCultures = new[]
            {
        new CultureInfo(defaultCulture),
        new CultureInfo("ar")
    };
            builder.Services.Configure<RequestLocalizationOptions>(options => {
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;


                // عشان نغير نخليه انه من خلال ال lg in URL
                options.RequestCultureProviders.Clear();

                //options.RequestCultureProviders.Add(new QueryStringRequestCultureProvider
                //    {
                //        QueryStringKey = "lg"              
                //    });

                options.RequestCultureProviders.Add(new AcceptLanguageHeaderRequestCultureProvider());
            });


            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService,CategoryService>();

            var app = builder.Build();

            app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
