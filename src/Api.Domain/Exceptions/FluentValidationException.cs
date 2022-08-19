using System.Linq;
using System;
using Api.Domain.Validations;
using FluentValidation.Results;

namespace Api.Domain.Exceptions
{
    public class FluentValidationException : Exception
    {
        public FluentValidationException(ValidationResult validationResult)
        {
            ErrorResponse = new ErrorResponse(validationResult.Errors.Select(e => new Error(e.PropertyName, e.ErrorMessage, e.AttemptedValue)).ToList());
        }

        public ErrorResponse ErrorResponse { get; private set; }
    }
}
