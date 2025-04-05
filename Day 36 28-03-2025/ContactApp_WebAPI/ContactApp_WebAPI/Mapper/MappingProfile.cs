using AutoMapper;
using ContactApp_WebAPI.Model.Entity;
using ContactApp_WebAPI.Model.UserDto;

namespace ContactApp_WebAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()     
        {
            CreateMap<User, LoginUserSuccessDto>();
            CreateMap<LoginUserSuccessDto, User>();

            CreateMap<User, LoginUserDto>();
            CreateMap<LoginUserDto, User>();

            CreateMap<User, GetAllUserDto>();
            CreateMap<GetAllUserDto, User>();

            CreateMap<User, AddUserDto>();
            CreateMap<AddUserDto, User>();

            CreateMap<User, UpdateUserActivationDto>();
            CreateMap<UpdateUserActivationDto, User>();

            CreateMap<User, UpdateUserNameDto>();
            CreateMap<UpdateUserNameDto, User>();
        }
    }
}
