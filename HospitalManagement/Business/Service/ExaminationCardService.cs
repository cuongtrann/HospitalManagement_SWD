using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using HospitalManagement.DataAccess.Repository;

namespace HospitalManagement.Business.Service
{
    public class ExaminationCardService : IExaminationCardService
    {

        SWD392_DBContext context;


        IExaminationCardRepository examinationCardRepository;

        public ExaminationCardService(SWD392_DBContext context)
        {
            this.context = context;
            examinationCardRepository = new ExaminationCardRepository(this.context);
        }

        public MedicalExaminationCard GetMedicalExaminationCard(int examinationCardId)
        {
            MedicalExaminationCard examinationCard = examinationCardRepository.GetMedicalExaminationCard(examinationCardId);
            return examinationCard;
        }
    }
}
