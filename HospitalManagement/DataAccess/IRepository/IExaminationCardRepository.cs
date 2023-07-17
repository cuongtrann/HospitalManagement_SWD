using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.IRepository
{
    public interface IExaminationCardRepository
    {
        MedicalExaminationCard GetMedicalExaminationCard(int examinationCardId);
    }
}
