using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Utilities.Paging;
using MediatR;
using static Fimple.FinalCase.Core.Features.AutomaticPayments.Constants.AutomaticPaymentsOperationClaims;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Queries.GetList;

public class GetListAutomaticPaymentQuery : IRequest<GetListResponse<GetListAutomaticPaymentListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListAutomaticPaymentQueryHandler : IRequestHandler<GetListAutomaticPaymentQuery, GetListResponse<GetListAutomaticPaymentListItemDto>>
    {
        private readonly IAutomaticPaymentRepository _automaticPaymentRepository;
        private readonly IMapper _mapper;

        public GetListAutomaticPaymentQueryHandler(IAutomaticPaymentRepository automaticPaymentRepository, IMapper mapper)
        {
            _automaticPaymentRepository = automaticPaymentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAutomaticPaymentListItemDto>> Handle(GetListAutomaticPaymentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AutomaticPayment> automaticPayments = await _automaticPaymentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAutomaticPaymentListItemDto> response = _mapper.Map<GetListResponse<GetListAutomaticPaymentListItemDto>>(automaticPayments);
            return response;
        }
    }
}