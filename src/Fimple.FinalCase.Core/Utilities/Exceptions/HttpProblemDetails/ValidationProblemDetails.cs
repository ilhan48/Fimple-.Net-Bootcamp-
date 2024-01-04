﻿using Fimple.FinalCase.Core.Utilities.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fimple.FinalCase.Core.Utilities.Exceptions.HttpProblemDetails;

internal class ValidationProblemDetails : ProblemDetails
{
    public IEnumerable<ValidationExceptionModel> Errors { get; init; }

    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Title = "Validation error(s)";
        Detail = "One or more validation errors occurred.";
        Errors = errors;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/probs/validation";
    }
}
