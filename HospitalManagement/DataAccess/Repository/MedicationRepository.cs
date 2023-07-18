﻿using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class MedicationRepository : IMedicationRepository
    {
        SWD392_DBContext context;

        public MedicationRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public List<Medication> GetMedication()
        {
            return context.Medications.ToList();
        }
        public void CreateMedication(Medication medication)
        {
            context.Medications.Add(medication);
            context.SaveChanges();
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
