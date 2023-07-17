using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using HospitalManagement.DataAccess.Repository;
namespace HospitalManagement.Business.Service
{
    public class MedicalCardService : IMedicalCardService
    {
        private IMedicalCardRepository MedicalCardRepository;
        private IPrescriptionRepository PrescriptionRepository;
        private InvoiceService InvoiceService;
        private IMedicalRecordRepository MedicalRecordRepository;
        private IPatientRepository PatientRepository;

        public MedicalCardService(IMedicalCardRepository medicalCardRepository, IPrescriptionRepository prescriptionRepository, InvoiceService invoiceService, IMedicalRecordRepository medicalRecordRepository)
        {
            MedicalCardRepository = medicalCardRepository;
            PrescriptionRepository = prescriptionRepository;
            InvoiceService = invoiceService;
            MedicalRecordRepository = medicalRecordRepository;
        }

        public void CreateMedicalCard(MedicalExaminationCard card)
        {
            
        }
    }
}
