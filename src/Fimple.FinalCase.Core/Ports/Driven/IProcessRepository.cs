using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven.Common;

namespace Fimple.FinalCase.Core.Ports.Driven;

public interface IProcessRepository : IAsyncRepository<Process, int>
{
}