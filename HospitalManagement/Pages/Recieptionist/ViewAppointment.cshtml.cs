using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HospitalManagement.Pages.Recieptionist
{
    public class ViewAppointmentModel : PageModel
    {
        private readonly IDepartmentService _departmentService;
        private readonly IAppointmentService _appointmentService;
        public List<Department> Departments { get; set; }
        private static List<Appointment> Appointments;
        public List<Appointment> AppointmentsPerPage { get; set; }

        private static int totalPage;
        private static int currentPage = 1;
        private static string _keyword = string.Empty;
        private static int _departmentId = 0;
        private static int _genderOption = 0;
        private static int _sortOption = 0;
        private static int _statusOption = -1;

        [BindProperty(SupportsGet = true)]
        public string KeyWord { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        private static readonly int _pageSize = 5;
        [BindProperty(SupportsGet = true)]
        public int? DepartmentId { get; set; }
        [BindProperty]
        public int? PatientId { get; set; }
        [BindProperty]
        public int? AppointmentStatus { get; set; }
        [BindProperty]
        public int? AppointmentId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? SortOption { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? GenderOption { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? StatusOption { get; set; }

        public ViewAppointmentModel(IDepartmentService departmentService, IAppointmentService appointmentService)
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
            Appointments = _appointmentService.LoadAll();
            if (KeyWord != null)
            {
                _keyword = KeyWord;
            }
            // Lọc danh sách sản phẩm theo các giá trị của các filter
            if (!string.IsNullOrEmpty(_keyword))
            {
                _keyword = _keyword.Trim().ToLower();
                Appointments = Appointments.Where(p => p.Patient.Profile.Name.ToLower().Contains(_keyword)
                || p.Patient.Profile.IdNo.ToLower().Contains(_keyword) || p.Patient.Profile.Phone.Contains(_keyword)
                || p.Patient.Profile.Email.ToLower().Contains(_keyword) || p.Patient.Profile.Address.ToLower().Contains(_keyword)
                || p.Department.Name.ToLower().Contains(_keyword)).ToList();
            }

            if (DepartmentId != null)
            {
                _departmentId = (int)DepartmentId;
            }

            if (_departmentId != 0)
            {
                Appointments = Appointments.Where(x => x.DepartmentId == _departmentId).ToList();
            }

            if (SortOption != null)
            {
                _sortOption = (int)SortOption;
            }
            if (_sortOption == 1)
            {
                Appointments = Appointments.OrderBy(x => x.Patient.Profile.Name).ToList();
            }
            else if (_sortOption == 2)
            {
                Appointments = Appointments.OrderByDescending(x => x.Patient.Profile.Name).ToList();
            }
            else if (_sortOption == 3)
            {
                Appointments = Appointments.OrderBy(x => x.Patient.Profile.Dob).ToList();
            }
            else if (_sortOption == 4)
            {
                Appointments = Appointments.OrderByDescending(x => x.Patient.Profile.Dob).ToList();
            }


            if (GenderOption != null)
            {
                _genderOption = (int)GenderOption;
            }

            if (_genderOption == 1)
            {
                Appointments = Appointments.Where(x => x.Patient.Profile.Gender == true).ToList();
            }
            else if (_genderOption == 2)
            {
                Appointments = Appointments.Where(x => x.Patient.Profile.Gender == false).ToList();
            }

            if(StatusOption != null)
            {
                _statusOption = (int)StatusOption;
            }

            if(_statusOption == 0)
            {
                Appointments = Appointments.Where(x => x.Status == 0).ToList();

            }
            else if(_statusOption == 1)
            {
                Appointments = Appointments.Where(x => x.Status == 1).ToList();
            }
            else if(_statusOption == 2)
            {
                Appointments = Appointments.Where(x => x.Status == 2).ToList();
            }


            // Tính toán vị trí bắt đầu và kết thúc của danh sách sản phẩm
            var startIndex = (id - 1) * _pageSize;
            var endIndex = startIndex + _pageSize;
            AppointmentsPerPage = Appointments.Skip(startIndex).Take(_pageSize).ToList();

            // Tính toán thông tin phân trang
            StatusOption = _statusOption;
            SortOption = _sortOption;
            GenderOption = _genderOption;
            DepartmentId = _departmentId;
            KeyWord = _keyword;
            totalPage = (int)Math.Ceiling((double)Appointments.Count() / _pageSize);
            TotalPage = totalPage;
            currentPage = id;
            CurrentPage = currentPage;
            Departments = _departmentService.LoadAll();
            return Page();
        }

        public IActionResult OnGetRefresh()
        {
            _sortOption = 0;
            _genderOption = 0;
            _statusOption = -1;
            _departmentId = 0;
            Appointments = _appointmentService.LoadAll();
            _keyword = string.Empty;
            currentPage = 1;
            return OnGetFilter(currentPage);
        }

        public IActionResult OnPostChangeStatus()
        {
            if (AppointmentId != null && AppointmentStatus != null)
            {
                if (_appointmentService.updateStatus(AppointmentId, AppointmentStatus))
                {
                    TempData["Message"] = "success";
                    
                }
                else
                {
                    TempData["Message"] = "fail";
                }
            }
            AppointmentStatus = 4;
            return OnGetFilter(currentPage);

        }
    }
}
