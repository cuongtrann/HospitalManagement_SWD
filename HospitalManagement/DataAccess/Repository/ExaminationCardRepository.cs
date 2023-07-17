using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class ExaminationCardRepository : IExaminationCardRepository
    {
        SWD392_DBContext context;

        public ExaminationCardRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public MedicalExaminationCard GetMedicalExaminationCard(int examinationCardId)
        {
            MedicalExaminationCard examinationCard = context.MedicalExaminationCards.FirstOrDefault(m => m.Id == examinationCardId);
            return examinationCard;
        }
    }
}
