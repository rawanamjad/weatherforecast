
using WeatherForecast.Application.Services;
using WeatherForecast.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Configuration.AddJsonFile("appsettings.json");
var apiConfig = builder.Configuration.GetSection("ApiConfig").Get<ApiConfig>();
builder.Services.AddSingleton(apiConfig);
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddTransient<IForecastService, ForecastService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

// Other service registrations

app.UseCors(builder => builder
        .WithOrigins("http://localhost:8080")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

// Other middlewares
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
 
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.Run();

