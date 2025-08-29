using RentalStore.Data;
using RentalStore.Repositories;
using RentalStore.Services;

namespace RentalStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRentalRepository, RentalRepository>();
            builder.Services.AddScoped<IFilmRepository, FilmRepository>();

            builder.Services.AddScoped<IRentalService, RentalService>();
            builder.Services.AddScoped<IFilmService, FilmService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddDbContext<RentalStoreContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
