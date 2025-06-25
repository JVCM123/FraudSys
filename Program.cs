using FraudSys.DataAccess.Config; 
using FraudSys.MVC.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var awsOptions = builder.Configuration.GetAWSOptions();
builder.Services.AddDefaultAWSOptions(awsOptions);

var dynamoConfig = builder.Configuration.GetSection("DynamoTables");
builder.Services.Configure<DbSettings>(dynamoConfig);

builder.Services.ResolveDependencies();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
