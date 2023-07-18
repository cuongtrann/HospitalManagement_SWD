 using HospitalManagement.Business.IService;
using HospitalManagement.Business.Service;
using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages
{
    public class CreateMedicalCardModel : PageModel
    {

        private IMedicalCardRepository MedicalCardRepository;
        private IPrescriptionRepository PrescriptionRepository;
        private IInvoiceService InvoiceService;
        private IMedicalRecordRepository MedicalRecordRepository;
        private IPatientRepository PatientRepository;
        private IDiseaseRepository DiseaseRepository;
        private ISymptonRepository SymptonRepository;

        static Patient patient { get; set; }
        public Patient Patient { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public List<Disease> ListDisease { get; set; }
        public List<Sympton> ListSympton { get; set; }
        public static Prescription Prescription { get; set; }
        public static Invoice Invoice { get; set; }

        [BindProperty]
        public int Disease { get; set; }
        [BindProperty]
        public int Sympton { get; set; }

        public CreateMedicalCardModel(IMedicalCardRepository medicalCardRepository, IPrescriptionRepository prescriptionRepository, IInvoiceService invoiceService, IMedicalRecordRepository medicalRecordRepository, IPatientRepository patientRepository, IDiseaseRepository diseaseRepository, ISymptonRepository symptonRepository)
        {
            MedicalCardRepository = medicalCardRepository;
            PrescriptionRepository = prescriptionRepository;
            InvoiceService = invoiceService;
            MedicalRecordRepository = medicalRecordRepository;
            PatientRepository = patientRepository;
            DiseaseRepository = diseaseRepository;
            SymptonRepository = symptonRepository;
        }

        public void OnGet(string? idNo)
        {
            if (string.IsNullOrEmpty(idNo))
            {
                return;
            }
            Patient = PatientRepository.GetByIdentifyNumber(idNo);
            patient = Patient;
            ListDisease = DiseaseRepository.GetAll();
            ListSympton = SymptonRepository.GetAll();
            MedicalRecord = MedicalRecordRepository.GetByPatientId(Patient.Id);
        }

        public IActionResult OnPostCreateMedicalCard()
        {
            MedicalRecord = MedicalRecordRepository.GetByPatientId(patient.Id);
            if (Invoice != null)
            {
                //send invoice and add to db
            }
            if (Prescription != null)
            {
                //add to db
                PrescriptionRepository.Create(Prescription);
            }

            MedicalExaminationCard card = new MedicalExaminationCard()
            {
                Id = 0,
                DiseaseId = Disease,
                SymptonId = Sympton,
                MedicalRecordId = MedicalRecord!=null?MedicalRecord.Id:null,
                PrescriptionId = Prescription!=null?Prescription.Id:null,
            };

            MedicalCardRepository.Create(card);
            Patient = patient;
            ListDisease = DiseaseRepository.GetAll();
            ListSympton = SymptonRepository.GetAll();
            MedicalRecord = MedicalRecordRepository.GetByPatientId(Patient.Id);

            return Page();
        }
    }
}
