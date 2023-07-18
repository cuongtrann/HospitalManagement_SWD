using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages.MedicationPages
{
    public class CreateMedicationModel : PageModel
    {
        IMedicationService medicationService;
        [BindProperty]
        public Medication Medication { get; set; }

        public void OnGet()
        {
            // Trang tạo mới thuốc không cần logic xử lý khi tải lần đầu
        }
        public string mess;
        public IActionResult OnPost(string Name, string Description, string DosageForm, string Interaction, string StorageCondition, string SideEffect, string Contraindication)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Thực hiện lưu thông tin thuốc vào cơ sở dữ liệu hoặc thực hiện các tác vụ cần thiết
            // ở đây, t chỉ in ra các thông tin thuốc đã nhập
            //Console.WriteLine("Id: " + Medication.Id);
            //Console.WriteLine("Name: " + Medication.Name);
            //Console.WriteLine("Description: " + Medication.Description);
            //Console.WriteLine("Dosage Form: " + Medication.DosageForm);
            //Console.WriteLine("Interaction: " + Medication.Interaction);
            //Console.WriteLine("Storage Condition: " + Medication.StorageCondition);
            //Console.WriteLine("Side Effect: " + Medication.SideEffect);
            //Console.WriteLine("Contraindication: " + Medication.Contraindication);
            // Chuyển hướng về trang danh sách thuốc hoặc trang khác tùy theo yêu cầu của bạn
            Medication medication = new Medication();
            medication.Name = Name;
            medication.Description = Description;
            medication.DosageForm = DosageForm;
            medication.Interaction = Interaction;
            medication.StorageCondition = StorageCondition;
            medication.SideEffect = SideEffect;
            medication.Contraindication = Contraindication;

            List<Medication> list = new List<Medication>();
            medicationService.CreateMedication(medication);
            mess = "Create Success!";
            return Page();
        }
    }
}
