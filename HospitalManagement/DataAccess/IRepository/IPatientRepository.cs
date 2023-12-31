﻿using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IPatientRepository
    {
        Patient GetById(int id);
        Patient GetByIdentifyNumber(string idNo);

        public void AddPatient(Patient patient);
        public List<Patient> GetAll();
        void UpdatePatientProfile(Profile patientProfile);
        Profile GetProfileById(int profileId);
    }
}
