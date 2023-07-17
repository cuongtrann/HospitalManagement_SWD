using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;

namespace HospitalManagement.DataAccess.Repository
{
    public class MedicalCardRepository : IMedicalCardRepository
    {
        SWD392_DBContext context;

        public MedicalCardRepository(SWD392_DBContext context)
        {
            this.context = context;
        }

        public void Create(MedicalExaminationCard card)
        {
            context.MedicalExaminationCards.Add(card);
            context.SaveChanges();
        }
    }
}
