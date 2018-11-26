using AutoMapper;
using quaneu.datalayer.Entities.Models.Users;

namespace quaneu.webapi.ViewModels.Mappings
{
    public class ViewModelToEntityMappingProfile : AutoMapper.Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
