using AutoMapper;
using BusinessObjects.Models;
using DataAccessObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.Implementation;
using Repository.Interfaces;
using Service;
using ShopServiceAPISystem.WebSocketMiddleware;
using System.Text;
using System.Text.Json.Serialization;

namespace ShopServiceAPISystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopService API", Version = "v1" });

                // Add JWT Authentication
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your token in the text input below.\n\nExample: \"Bearer abc123\"",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policyBuilder =>
                {
                    policyBuilder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                });
            });

            // Register your services and repositories
            builder.Services.AddScoped<UserDAO>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<ProductDAO>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<BlogDAO>();
            builder.Services.AddScoped<IBlogRepository, BlogRepository>();
            builder.Services.AddScoped<BlogService>();
            builder.Services.AddScoped<OrderDAO>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<OrderDetailDAO>();
            builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            builder.Services.AddScoped<OrderDetailService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<CategoryDAO>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            builder.Services.AddScoped<FeedbackDAO>();
            builder.Services.AddScoped<FeedbackService>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<ServiceDAO>();
            builder.Services.AddScoped<ServiceService>();
            builder.Services.AddScoped<IShippingRepository, ShippingRepository>();
            builder.Services.AddScoped<ShippingDAO>();
            builder.Services.AddScoped<ShippingService>();
            builder.Services.AddScoped<IVoucherRepository, VoucherRepository>();
            builder.Services.AddScoped<VoucherDAO>();
            builder.Services.AddScoped<VoucherService>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<CartDAO>();
            builder.Services.AddScoped<CartService>();
            builder.Services.AddScoped<ICartProductRepository, CartProductRepository>();
            builder.Services.AddScoped<CartProductDAO>();
            builder.Services.AddScoped<CartProductService>();


            // AutoMapper configuration
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // JWT Authentication configuration
            var secretKey = builder.Configuration["AppSettings:SecretKey"];
            var secretKeyByte = Encoding.UTF8.GetBytes(secretKey);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyByte),
                    ClockSkew = TimeSpan.Zero
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.UseWebSockets();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/ws")
                {
                    await WebSocketHandler.HandleWebSocket(context);
                }
                else
                {
                    await next();
                }
            });
            app.Run();
        }
    }
}
