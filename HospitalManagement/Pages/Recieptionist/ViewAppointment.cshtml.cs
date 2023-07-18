using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
        private static string _keyword;
        [BindProperty(SupportsGet = true)]
        public string KeyWord { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        private static readonly int _pageSize = 5;
        [BindProperty]
        public int? DepartmentId { get; set; }
        [BindProperty]
        public int? PatientId { get; set; }
        [BindProperty]
        public int? AppointmentStatus { get; set; }

        public ViewAppointmentModel(IDepartmentService departmentService, IAppointmentService appointmentService)
        {
            _departmentService = departmentService;
            _appointmentService = appointmentService;
        }

        public void OnGet()
        {
            OnGetFilter(_keyword, currentPage);
        }

        public IActionResult OnGetFilter(string? sortOption, int id)
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

            if(DepartmentId != null)
            {
                if(DepartmentId != 0)
                {
                    Appointments = Appointments.Where(x => x.DepartmentId == DepartmentId).ToList();
                }
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
            AppointmentsPerPage = Appointments.Skip(startIndex).Take(_pageSize).ToList();

            // Tính toán thông tin phân trang
            KeyWord = _keyword;
            totalPage = (int)Math.Ceiling((double)Appointments.Count() / _pageSize);
            TotalPage = totalPage;
            currentPage = id;
            CurrentPage = currentPage;
            Departments = _departmentService.LoadAll();
            return Page();
        }
    }
}
