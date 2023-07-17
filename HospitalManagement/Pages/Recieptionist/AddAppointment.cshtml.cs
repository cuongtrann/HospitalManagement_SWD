using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace HospitalManagement.Pages.Recieptionist
{
    public class AddAppointmentModel : PageModel
    {
        private readonly IDepartmentService _departmentService;
        private readonly IAppointmentService _appointmentService;
        public List<Department> Departments { get; set; }
        private static  List<Patient> Patients;
        public List<Patient> PatientsPerPage { get; set; }

        private static int totalPage;
        private static int currentPage = 1;
        private static string _keyword;
        [BindProperty(SupportsGet = true)]
        public string KeyWord { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        private static readonly int _pageSize = 5;
        public AddAppointmentModel(IDepartmentService departmentService, IAppointmentService appointmentService)
        {
            _departmentService = departmentService;
            _appointmentService = appointmentService;
        }

        public void OnGet()
        {
            OnGetFilter(string.Empty,currentPage);
        }
        private void LoadDataBegin()
        {
            SWD392_DBContext sWD392_DBContext = new SWD392_DBContext();
            Departments = _departmentService.LoadAll();
            // Sua lai them phan cua Mai sau
            
            Patients = Patients.Skip(0).Take(10).ToList();
            CurrentPage = 1;
        }

        public IActionResult OnGetFilter(string? sortOption, int id)
        {
            // Sua lai them phan cua Mai sau
            
            
            
            SWD392_DBContext sWD392_DBContext = new SWD392_DBContext();
            Patients = sWD392_DBContext.Patients.Include(x => x.Profile).ToList();

            // Lọc danh sách sản phẩm theo các giá trị của các filter
            if (!string.IsNullOrEmpty(KeyWord))
            {
                KeyWord = KeyWord.Trim().ToLower();
                Patients = Patients.Where(p => p.Profile.Name.ToLower().Contains(KeyWord) 
                || p.Profile.IdNo.ToLower().Contains(KeyWord) || p.Profile.Phone.Contains(KeyWord) 
                || p.Profile.Email.ToLower().Contains(KeyWord) || p.Profile.Address.ToLower().Contains(KeyWord)).ToList();
            }

            //if (!string.IsNullOrEmpty(sortOption))
            //{
            //    if (sortOption == "NameAsc")
            //    {
            //        productList = productList.OrderBy(p => p.ProductName).ToList();
            //    }
            //    else if (sortOption == "NameDesc")
            //    {
            //        productList = productList.OrderByDescending(p => p.ProductName).ToList();
            //    }
            //    else if (sortOption == "PriceAsc")
            //    {
            //        productList = productList.OrderBy(p => p.UnitPrice).ToList();
            //    }
            //    else if (sortOption == "PriceDesc")
            //    {
            //        productList = productList.OrderByDescending(p => p.UnitPrice).ToList();
            //    }
            //}
            // Tính toán vị trí bắt đầu và kết thúc của danh sách sản phẩm
            var startIndex = (id - 1) * _pageSize;
            var endIndex = startIndex + _pageSize;
            PatientsPerPage = Patients.Skip(startIndex).Take(_pageSize).ToList();

            // Tính toán thông tin phân trang
            _keyword = KeyWord;
            this.KeyWord = _keyword;
            totalPage = (int)Math.Ceiling((double)Patients.Count() / _pageSize);
            TotalPage = totalPage;
            currentPage = id;
            CurrentPage = currentPage;
            Departments = _departmentService.LoadAll();
            return Page();
        }
    }
}
