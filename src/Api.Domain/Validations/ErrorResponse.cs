using System.Collections.Generic;
using FluentValidation.Results;

namespace Api.Domain.Validations
{
    public class ErrorResponse
    {
        public ErrorResponse(List<Error> errors)
        {
            Errors = errors;
        }

        public List<Error> Errors { get; set; }
    }
}
