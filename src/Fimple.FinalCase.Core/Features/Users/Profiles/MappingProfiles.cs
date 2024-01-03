using AutoMapper;
using Fimple.FinalCase.Core.DTOs;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.Users.Commands.Create;
using Fimple.FinalCase.Core.Features.Users.Commands.Delete;
using Fimple.FinalCase.Core.Features.Users.Commands.Update;
using Fimple.FinalCase.Core.Features.Users.Commands.UpdateFromAuth;
using Fimple.FinalCase.Core.Features.Users.Queries.GetById;
using Fimple.FinalCase.Core.Utilities.Paging;

namespace Fimple.FinalCase.Core.Features.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreatedUserResponse>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, UpdatedUserResponse>().ReverseMap();
        CreateMap<User, UpdateUserFromAuthCommand>().ReverseMap();
        CreateMap<User, UpdatedUserFromAuthResponse>().ReverseMap();
        CreateMap<User, DeleteUserCommand>().ReverseMap();
        CreateMap<User, DeletedUserResponse>().ReverseMap();
        CreateMap<User, GetByIdUserResponse>().ReverseMap();
        CreateMap<User, ListUserDto>().ReverseMap();
        CreateMap<IPaginate<User>, GetListResponse<ListUserDto>>().ReverseMap();
    }
}
