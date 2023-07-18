using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using HospitalManagement.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages.PrescriptionV
{
    public class CreatePrescriptionModel : PageModel
    {
        IMedicationRepository medicationService;
        IPrescriptionRepository prescriptionService;
        string patientId = "1";
        string doctorId = "2";

        public CreatePrescriptionModel(IMedicationRepository medicationRepository, IPrescriptionRepository prescriptionService)
        {
            this.medicationService = medicationRepository;
            this.prescriptionService = prescriptionService;
        }
        public List<Medication> MedicatioinList;
        public List<User> UserList;
        public List<Profile> ProfileList;
        public void OnGet()
        {
            MedicatioinList = medicationService.GetAll();
            UserList = prescriptionService.GetAllUser();
            ProfileList = prescriptionService.GetAllProfile();
        }


        public IActionResult OnPostCreatePrescriiption()
        {
            List<KeyValuePair<string, int>> selectedItems = new List<KeyValuePair<string, int>>();

            foreach (string key in Request.Form.Keys)
            {
                if (key == "selectedItems" && Request.Form[key].Count > 0)
                {
                    foreach (var itemId in Request.Form[key])
                    {
                        string quantityKey = "quantities[" + itemId + "]";
                        if (Request.Form.ContainsKey(quantityKey))
                        {
                            int val;
                            if (int.TryParse(Request.Form[quantityKey], out val))
                            {
                                selectedItems.Add(new KeyValuePair<string, int>(itemId, val));
                            }
                        }
                    }
                }
            }
            SWD392_DBContext context = new SWD392_DBContext();
            Prescription prescription = new Prescription();
            prescription.CreatedAt = DateTime.Now;
            prescription.DoctorId = int.Parse(doctorId);
            prescription.PatientId = int.Parse(patientId);
            context.Prescriptions.Add(prescription);
            context.SaveChanges();
            Prescription newestPrescription = context.Prescriptions.OrderByDescending(p => p.CreatedAt).FirstOrDefault();
            if (newestPrescription != null)
            {
                foreach (var item in selectedItems)
                {
                    PrescriptionDetail prescriptionDetail = new PrescriptionDetail();
                    prescriptionDetail.MedicationQuantity = item.Value.ToString();
                    prescriptionDetail.MedicationId = int.Parse(item.Key);
                    prescriptionDetail.PrescriptionId = newestPrescription.Id;
                    prescriptionDetail.MedicationFrequency = "Ok";
                    context.PrescriptionDetails.Add(prescriptionDetail);
                    context.SaveChanges();
                }
            }
            OnGet();
            return RedirectToPage("/PrescriptionV/AddPrescription", new { handler = "AddPrescription" });
        }
    }
}
