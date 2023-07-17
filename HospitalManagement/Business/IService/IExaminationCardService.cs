using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.Business.IService
{
    public interface IExaminationCardService
    {
        MedicalExaminationCard GetMedicalExaminationCard(int examinationCardId);
    }
}
