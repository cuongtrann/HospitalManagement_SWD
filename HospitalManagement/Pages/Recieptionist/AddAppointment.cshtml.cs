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
        private static int _genderOption = 0;
        private static int _sortOption = 0;

        [BindProperty(SupportsGet = true)]
        public string KeyWord { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        private static readonly int _pageSize = 5;
        [BindProperty]
        public int? DepartmentId { get; set; }
        [BindProperty]
        public int? PatientId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? SortOption { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? GenderOption { get; set; }
        public AddAppointmentModel(IDepartmentService departmentService, IAppointmentService appointmentService)
        {
            _departmentService = departmentService;
            _appointmentService = appointmentService;
        }

        public void OnGet()
        {
            OnGetFilter(currentPage);
        }

        public IActionResult OnGetFilter(int id)
        {
            // Sua lai them phan cua Mai sau
            SWD392_DBContext sWD392_DBContext = new SWD392_DBContext();
            Patients = sWD392_DBContext.Patients.Include(x => x.Profile).ToList();
            if (KeyWord != null)
            {
                _keyword = KeyWord;
            }
            // Lọc danh sách sản phẩm theo các giá trị của các filter
            if (!string.IsNullOrEmpty(_keyword))
            {
                _keyword = _keyword.Trim().ToLower();
                Patients = Patients.Where(p => p.Profile.Name.ToLower().Contains(_keyword) 
                || p.Profile.IdNo.ToLower().Contains(_keyword) || p.Profile.Phone.Contains(_keyword) 
                || p.Profile.Email.ToLower().Contains(_keyword) || p.Profile.Address.ToLower().Contains(_keyword)).ToList();
            }

            if (SortOption != null)
            {
                _sortOption = (int)SortOption;
            }
            if (_sortOption == 1)
            {
                Patients = Patients.OrderBy(x => x.Profile.Name).ToList();
            }
            else if (_sortOption == 2)
            {
                Patients = Patients.OrderByDescending(x => x.Profile.Name).ToList();
            }
            else if (_sortOption == 3)
            {
                Patients = Patients.OrderBy(x => x.Profile.Dob).ToList();
            }
            else if (_sortOption == 4)
            {
                Patients = Patients.OrderByDescending(x => x.Profile.Dob).ToList();
            }

            if (GenderOption != null)
            {
                _genderOption = (int)GenderOption;
            }

            if (_genderOption == 1)
            {
                Patients = Patients.Where(x => x.Profile.Gender == true).ToList();
            }
            else if (_genderOption == 2)
            {
                Patients = Patients.Where(x => x.Profile.Gender == false).ToList();
            }
            // Tính toán vị trí bắt đầu và kết thúc của danh sách sản phẩm
            var startIndex = (id - 1) * _pageSize;
            var endIndex = startIndex + _pageSize;
            PatientsPerPage = Patients.Skip(startIndex).Take(_pageSize).ToList();

            // Tính toán thông tin phân trang
            SortOption = _sortOption;
            GenderOption = _genderOption;
            KeyWord = _keyword;
            totalPage = (int)Math.Ceiling((double)Patients.Count() / _pageSize);
            TotalPage = totalPage;
            currentPage = id;
            CurrentPage = currentPage;
            Departments = _departmentService.LoadAll();
            return Page();
        }

        public IActionResult OnPostAddAppointment()
        {
            if (DepartmentId != null && PatientId != null)
            {
                Department depart = _departmentService.GetById((int)DepartmentId);
                if(depart != null)
                {
                    var now = DateTime.Now;
                    var assignments = depart.Assignments
                    .Where(a => a.From <= now && now <= a.To)
                    .ToList();
                    if(assignments.Count == 0) {
                        TempData["Message"] = "fail";
                        return OnGetFilter(currentPage);
                    }
                    _appointmentService.AddAppointment(new Appointment()
                    {
                        DepartmentId = depart.Id,
                        PatientId = PatientId,
                        Status = 0
                    });
                    TempData["Message"] = "success";
                }
            }
            return OnGetFilter(currentPage);
        }

        public IActionResult OnGetRefresh()
        {
            // Sua lai them phan cua Mai sau
            _sortOption = 0;
            _genderOption = 0;
            SWD392_DBContext sWD392_DBContext = new SWD392_DBContext();
            Patients = sWD392_DBContext.Patients.Include(x => x.Profile).ToList();
            _keyword = string.Empty;
            currentPage = 1;
            return OnGetFilter(currentPage);
        }
    }
}
