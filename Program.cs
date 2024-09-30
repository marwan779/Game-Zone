
var builder = WebApplication.CreateBuilder(args);

// Get the Connection string from the appsetting.json file 
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (ConnectionString == null) throw new Exception("DefaultConnection is Null");

// Regester the DbContext with dependency injection and connection string
builder.Services.AddDbContext<ApplicationDbContext>
	(options => options.UseSqlServer(ConnectionString));

// Regester the Category, Device and Game Services 

builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IDeviceServices, DeviceServices>();
builder.Services.AddScoped<IGameServices, GameServices>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
