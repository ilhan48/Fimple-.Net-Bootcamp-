using Fimple.FinalCase.Core.Features.Accounts.Commands.Create;
using Fimple.FinalCase.Core.Features.Accounts.Commands.Delete;
using Fimple.FinalCase.Core.Features.Accounts.Commands.Update;
using Fimple.FinalCase.Core.Features.Accounts.Queries.GetById;
using Fimple.FinalCase.Core.Features.Accounts.Queries.GetList;
using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Utilities.Paging;

namespace Fimple.FinalCase.Core.Features.Accounts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Account, CreateAccountCommand>().ReverseMap();
        CreateMap<Account, CreatedAccountResponse>().ReverseMap();
        CreateMap<Account, UpdateAccountCommand>().ReverseMap();
        CreateMap<Account, UpdatedAccountResponse>().ReverseMap();
        CreateMap<Account, DeleteAccountCommand>().ReverseMap();
        CreateMap<Account, DeletedAccountResponse>().ReverseMap();
        CreateMap<Account, GetByIdAccountResponse>().ReverseMap();
        CreateMap<Account, GetListAccountListItemDto>().ReverseMap();
        CreateMap<IPaginate<Account>, GetListResponse<GetListAccountListItemDto>>().ReverseMap();
    }
}