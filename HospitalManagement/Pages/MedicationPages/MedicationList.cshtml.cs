using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages.MedicationPages
{
    public class MedicationListsModel : PageModel
    {
        IMedicationRepository medicationRepository;

        public List<Medication> Medications { get; set; }

        public MedicationListsModel(IMedicationRepository medicationRepository)
        {
            this.medicationRepository = medicationRepository;
        }

        public void OnGet()
        {
            Medications = medicationRepository.GetMedication();
        }

    }
}
