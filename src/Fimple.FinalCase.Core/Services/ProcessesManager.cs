using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Features.Processes.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Services;

public class ProcessesManager : IProcessesService
{
    private readonly IProcessRepository _processRepository;
    private readonly ProcessBusinessRules _processBusinessRules;

    public ProcessesManager(IProcessRepository processRepository, ProcessBusinessRules processBusinessRules)
    {
        _processRepository = processRepository;
        _processBusinessRules = processBusinessRules;
    }

    public async Task<Process?> GetAsync(
        Expression<Func<Process, bool>> predicate,
        Func<IQueryable<Process>, IIncludableQueryable<Process, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Process? process = await _processRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return process;
    }

    public async Task<IPaginate<Process>?> GetListAsync(
        Expression<Func<Process, bool>>? predicate = null,
        Func<IQueryable<Process>, IOrderedQueryable<Process>>? orderBy = null,
        Func<IQueryable<Process>, IIncludableQueryable<Process, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Process> processList = await _processRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return processList;
    }

    public async Task<Process> AddAsync(Process process)
    {
        Process addedProcess = await _processRepository.AddAsync(process);

        return addedProcess;
    }

    public async Task<Process> UpdateAsync(Process process)
    {
        Process updatedProcess = await _processRepository.UpdateAsync(process);

        return updatedProcess;
    }

    public async Task<Process> DeleteAsync(Process process, bool permanent = false)
    {
        Process deletedProcess = await _processRepository.DeleteAsync(process);

        return deletedProcess;
    }
}
