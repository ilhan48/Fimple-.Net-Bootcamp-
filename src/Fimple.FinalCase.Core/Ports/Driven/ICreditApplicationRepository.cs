using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Ports.Driven.Common;

namespace Fimple.FinalCase.Core.Ports.Driven;

public interface ICreditApplicationRepository : IAsyncRepository<CreditApplication, int>
{
}