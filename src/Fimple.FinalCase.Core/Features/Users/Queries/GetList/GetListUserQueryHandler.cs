using AutoMapper;
using Fimple.FinalCase.Core.DTOs;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Paging;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Users.Queries.GetList;
public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, GetListResponse<GetListUserListItemDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserListItemDto>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ListUserDto> users = await _userRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserListItemDto> response = _mapper.Map<GetListResponse<GetListUserListItemDto>>(users);
            return response;
        }
    }

