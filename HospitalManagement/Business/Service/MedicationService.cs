using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.Service
{
    public class MedicationService : IMedicationService
    {
        SWD392_DBContext context;

        public MedicationService(SWD392_DBContext context)
        {
            this.context = context;
        }


        public void CreateMedication(Medication medication)
        {
            context.Medications.Add(medication);
            context.SaveChanges();
        }

        public List<Medication> GetAllMedications()
        {
            return context.Medications.ToList();
        }

        public Medication GetMedicationById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMedication(Medication medication)
        {
            var existingMedication = context.Medications.FirstOrDefault(m => m.Id == medication.Id);
            if (existingMedication != null)
            {
                existingMedication.Name = medication.Name;
                existingMedication.Description = medication.Description;
                existingMedication.DosageForm = medication.DosageForm;
                existingMedication.Interaction = medication.Interaction;
                existingMedication.StorageCondition = medication.StorageCondition;
                existingMedication.SideEffect = medication.SideEffect;
                existingMedication.Contraindication = medication.Contraindication;

                context.SaveChanges();
            }
        }
    }
}
