using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.IService
{
    public interface IMedicalCardService
    {
        void CreateMedicalCard(MedicalExaminationCard card);
    }
}
