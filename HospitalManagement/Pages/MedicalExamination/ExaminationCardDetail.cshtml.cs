using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalManagement.Pages.MedicalExamination
{
    public class ExaminationCardDetailModel : PageModel
    {

        public MedicalExaminationCard Card { get; set; }

        public User User { get; set; }

        public Profile Profile { get; set; }

        IExaminationCardRepository examinationCardRepository;
        IProfileRepository profileRepository;
        IUserRepository userRepository;

        public ExaminationCardDetailModel(IExaminationCardRepository examinationCardRepository, IProfileRepository profileRepository, IUserRepository userRepository)
        {
            this.examinationCardRepository = examinationCardRepository;
            this.profileRepository = profileRepository;
            this.userRepository = userRepository;
        }

        public void OnGet(int id)
        {
            Card = examinationCardRepository.GetMedicalExaminationCard(id);
            User = userRepository.GetUser((int)Card.DoctorId);
            Profile = profileRepository.GetProfile((int)User.ProfileId);

        }
    }
}
