using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IMedicalCardRepository
    {
        void Create(MedicalExaminationCard card);
    }
}
