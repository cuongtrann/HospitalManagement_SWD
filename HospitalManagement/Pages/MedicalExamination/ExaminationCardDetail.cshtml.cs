using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages.MedicalExamination
{
    public class ExaminationCardDetailModel : PageModel
    {

        public MedicalExaminationCard Card { get; set; }

        public User User { get; set; }

        public Profile ProfileDoctor { get; set; }

        public Profile ProfilePatient { get; set; }

        public MedicalRecord MedicalRecord { get; set; }

        public Patient Patient { get; set; }

        public Sympton Sympton { get; set; }

        public Disease Disease { get; set; }

        public List<PrescriptionDetail> PrescriptionDetails { get; set; }

        public List<Medication> Medications { get; set; } = new List<Medication>();

        IExaminationCardRepository examinationCardRepository;
        IProfileRepository profileRepository;
        IUserRepository userRepository;
        IMedicalRecordRepository medicalRecordRepository;
        IPatientRepository patientRepository;
        ISymptonRepository symptonRepository;
        IDiseaseRepository diseaseRepository;
        IPrescriptionDetailRepository prescriptionDetailRepository;
        IMedicationRepository medicationRepository;

        public ExaminationCardDetailModel(IExaminationCardRepository examinationCardRepository, IProfileRepository profileRepository, 
            IUserRepository userRepository, IMedicalRecordRepository medicalRecordRepository, IPatientRepository patientRepository, 
            ISymptonRepository symptonRepository, IDiseaseRepository diseaseRepository, IPrescriptionDetailRepository prescriptionDetailRepository,
            IMedicationRepository medicationRepository)
        {
            this.examinationCardRepository = examinationCardRepository;
            this.profileRepository = profileRepository;
            this.userRepository = userRepository;
            this.medicalRecordRepository = medicalRecordRepository;
            this.patientRepository = patientRepository;
            this.symptonRepository = symptonRepository;
            this.diseaseRepository = diseaseRepository;
            this.prescriptionDetailRepository = prescriptionDetailRepository;
            this.medicationRepository = medicationRepository;
        }

        public void OnGet(int id)
        {
            Card = examinationCardRepository.GetMedicalExaminationCard(id);
            User = userRepository.GetUser((int)Card.DoctorId);
            ProfileDoctor = profileRepository.GetProfile((int)User.ProfileId);

            MedicalRecord = medicalRecordRepository.GetMedicalRecord((int)Card.MedicalRecordId);
            Patient = patientRepository.GetById((int)MedicalRecord.PatientId);
            ProfilePatient = profileRepository.GetProfile((int)Patient.ProfileId);

            Sympton = symptonRepository.GetById((int)Card.SymptonId);
            Disease = diseaseRepository.GetById((int)Card.DiseaseId);
            PrescriptionDetails = prescriptionDetailRepository.GetAllByPrescriptionId((int)Card.PrescriptionId);
            PrescriptionDetails.ForEach(p =>
            {
                Medication medication = medicationRepository.GetMedication((int)p.MedicationId);
                Medications.Add(medication);
            });
        }
    }
}
