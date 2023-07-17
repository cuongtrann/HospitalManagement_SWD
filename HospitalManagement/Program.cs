using HospitalManagement.Business.IService;
using HospitalManagement.Business.Service;
using HospitalManagement.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IPatientService, PatientService>().AddDbContext<SWD392_DBContext>(opt =>
    builder.Configuration.GetConnectionString("SWD392_DBContext"));
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

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

app.Run();
