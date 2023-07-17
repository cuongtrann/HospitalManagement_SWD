using HospitalManagement.Business.IService;
using HospitalManagement.Business.Service;
using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using HospitalManagement.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<SWD392_DBContext>();
builder.Services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<IAppointmentService, AppointmentService>();
builder.Services.AddSingleton<IAppointmentRepository, AppointmentRepository>();


builder.Services.AddSingleton<SWD392_DBContext>();

builder.Services.AddSingleton<IDiseaseRepository, DiseaseRepository>();
builder.Services.AddSingleton<ISymptonRepository, SymptonRepository>();
builder.Services.AddSingleton<IMedicalCardRepository, MedicalCardRepository>();
builder.Services.AddSingleton<IMedicalRecordRepository, MedicalRecordRepository>();
builder.Services.AddSingleton<IPatientRepository, PatientRepository>();
builder.Services.AddSingleton<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddSingleton<IInvoiceDetailRepository, InvoiceDetailRepository>();
builder.Services.AddSingleton<IServiceRepository, ServiceRepository>();
builder.Services.AddSingleton<IServiceRepository, ServiceRepository>();


builder.Services.AddSingleton<IPatientService, PatientService>();
builder.Services.AddSingleton<IInvoiceService, InvoiceService>();




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
