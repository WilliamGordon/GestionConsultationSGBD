using AutoMapper;
using BLL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessServices
{
    public class ConsultationService
    {
        private DAL.Repositories.ConsultationRepository Repo { get; set; }
        private IMapper Mapper { get; set; }

        public ConsultationService()
        {
            Repo = new DAL.Repositories.ConsultationRepository();
            Mapper = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfileConfiguration())).CreateMapper();
        }
        public List<Models.Consultation> GetAllConsultationForPatient(int id)
        {
            Repo.GetAllConsultationForPatient(id);
            return Mapper.Map<List<Models.Consultation>>(Repo.GetAllConsultationForPatient(id));
        }
    }
}
