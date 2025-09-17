using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.DI
{
    /// <summary>
    /// Dependency Injection configuration for Persistence layer
    /// </summary>
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            // DbContext
            services.AddScoped<MyContext>();

            // Repositories
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICarDescriptionRepository, CarDescriptionRepository>();
            services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
            services.AddScoped<ICarPricingRepository, CarPricingRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IFooterAddressRepository, FooterAddressRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IPricingRepository, PricingRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            // Services
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
