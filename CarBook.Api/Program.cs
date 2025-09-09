using CarBook.Application.DI;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<MyContext>();// DbContext kaydý.
builder.Services.AddApplicationServices(builder.Configuration);// Application katmanýndaki servislerin kaydý.
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository),typeof(CarRepository));
builder.Services.AddScoped(typeof(IBrandRepository),typeof(BrandRepository));
builder.Services.AddScoped(typeof(IBannerRepository),typeof(BannerRepository));
builder.Services.AddScoped(typeof(IAboutRepository),typeof(AboutRepository));
builder.Services.AddScoped(typeof(ICategoryRepository),typeof(CategoryRepository));
builder.Services.AddScoped(typeof(IContactRepository),typeof(ContactRepository));
builder.Services.AddScoped(typeof(IFeatureRepository),typeof(FeatureRepository));
builder.Services.AddScoped(typeof(ISocialMediaRepository),typeof(SocialMediaRepository));
builder.Services.AddScoped(typeof(ITestimonialRepository),typeof(TestimonialRepository));
builder.Services.AddScoped(typeof(IServiceRepository),typeof(ServiceRepository));
builder.Services.AddScoped(typeof(IPricingRepository),typeof(PricingRepository));
builder.Services.AddScoped(typeof(ILocationRepository),typeof(LocationRepository));
builder.Services.AddScoped(typeof(IFooterAddressRepository),typeof(FooterAddressRepository));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
