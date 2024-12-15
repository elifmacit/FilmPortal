using FilmPortal.Business.Services;
using FilmPortal.Core.Interfaces;
using FilmPortal.Data.Context;
using FilmPortal.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.Business.Services;
using Project.Core.Interfaces;
using Project.Data.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContextPool<FilmPortalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Repository Layer
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IMovieCategoryRepository, MovieCategoryRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IMovieLikeRepository, MovieLikeRepository>();
builder.Services.AddScoped<IMovieReviewRepository, MovieReviewRepository>();

// Service Layer
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<MovieCategoryService>();
builder.Services.AddScoped<DirectorService>();
builder.Services.AddScoped<MovieLikeService>();
builder.Services.AddScoped<MovieReviewService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
