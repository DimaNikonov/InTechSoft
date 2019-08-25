using AutoMapper;
using TestTaskWebApi.API.Entities;
using TestTaskWebApi.DAL.Entitties;

namespace TestTaskWebApi.API.Mapping
{
    public class FaqQuestionMapping : Profile
    {
        public FaqQuestionMapping()
        {
            this.CreateMap<FaqQuestion, FaqQuestionViewModel>().ReverseMap();
            this.CreateMap<CreateFaqQuestionViewModel, FaqQuestion>();
        }
    }
}
