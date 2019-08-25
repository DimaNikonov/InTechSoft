using AutoMapper;
using TestTaskWebApi.API.Entities;
using TestTaskWebApi.DAL.Entitties;

namespace TestTaskWebApi.API.Mapping
{
    public class FaqGroupMapping : Profile
    {
        public FaqGroupMapping()
        {
            this.CreateMap<FaqGroup, FaqGroupViewModel>().ReverseMap();
            this.CreateMap<CreateFaqGroupViewModel, FaqGroup>();
        }
    }
}
