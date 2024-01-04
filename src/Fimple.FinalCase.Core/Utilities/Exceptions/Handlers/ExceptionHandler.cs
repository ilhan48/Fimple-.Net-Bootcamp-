using Fimple.FinalCase.Core.Utilities.Exceptions.Types;

namespace Fimple.FinalCase.Core.Utilities.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception) =>
        exception switch
        {
            BusinessException businessException => HandleException(businessException),
            AuthorizationException authorizationException => HandleException(authorizationException),
            NotFoundException notFoundException => HandleException(notFoundException),
            _ => HandleException(exception)
        };

    protected abstract Task HandleException(BusinessException businessException);
    protected abstract Task HandleException(AuthorizationException authorizationException);
    protected abstract Task HandleException(NotFoundException notFoundException);
    protected abstract Task HandleException(Exception exception);
}
