using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Utilities.Paging;
using MediatR;
using static Fimple.FinalCase.Core.Features.CreditApplications.Constants.CreditApplicationsOperationClaims;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Queries.GetList;

public class GetListCreditApplicationQuery : IRequest<GetListResponse<GetListCreditApplicationListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCreditApplicationQueryHandler : IRequestHandler<GetListCreditApplicationQuery, GetListResponse<GetListCreditApplicationListItemDto>>
    {
        private readonly ICreditApplicationRepository _creditApplicationRepository;
        private readonly IMapper _mapper;

        public GetListCreditApplicationQueryHandler(ICreditApplicationRepository creditApplicationRepository, IMapper mapper)
        {
            _creditApplicationRepository = creditApplicationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCreditApplicationListItemDto>> Handle(GetListCreditApplicationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CreditApplication> creditApplications = await _creditApplicationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCreditApplicationListItemDto> response = _mapper.Map<GetListResponse<GetListCreditApplicationListItemDto>>(creditApplications);
            return response;
        }
    }
}