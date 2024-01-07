using Fimple.FinalCase.Core.Features.AutomaticPayments.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Delete;

public class DeleteAutomaticPaymentCommandHandler : IRequestHandler<DeleteAutomaticPaymentCommand, DeletedAutomaticPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAutomaticPaymentRepository _automaticPaymentRepository;
        private readonly AutomaticPaymentBusinessRules _automaticPaymentBusinessRules;

        public DeleteAutomaticPaymentCommandHandler(IMapper mapper, IAutomaticPaymentRepository automaticPaymentRepository,
                                         AutomaticPaymentBusinessRules automaticPaymentBusinessRules)
        {
            _mapper = mapper;
            _automaticPaymentRepository = automaticPaymentRepository;
            _automaticPaymentBusinessRules = automaticPaymentBusinessRules;
        }

        public async Task<DeletedAutomaticPaymentResponse> Handle(DeleteAutomaticPaymentCommand request, CancellationToken cancellationToken)
        {
            AutomaticPayment? automaticPayment = await _automaticPaymentRepository.GetAsync(predicate: ap => ap.Id == request.Id, cancellationToken: cancellationToken);
            await _automaticPaymentBusinessRules.AutomaticPaymentShouldExistWhenSelected(automaticPayment);

            await _automaticPaymentRepository.DeleteAsync(automaticPayment!);

            DeletedAutomaticPaymentResponse response = _mapper.Map<DeletedAutomaticPaymentResponse>(automaticPayment);
            return response;
        }
    }