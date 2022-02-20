using API.Model;
using API.ViewModel;
using AutoMapper;

namespace API.Mappings
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<CreatePersonViewModel, Person>();
            CreateMap<UpdatePersonViewModel, Person>();
        }
    }
}
