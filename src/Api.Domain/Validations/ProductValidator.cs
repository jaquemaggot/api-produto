using System;
using Api.Domain.Entities;
using FluentValidation;

namespace Api.Domain.Validations
{
    public class ProductValidator : AbstractValidator<ProductEntity>
    {
        public ProductValidator()
        {
            var now = DateTime.Now;

            RuleFor(p => p.Title).NotEmpty().WithMessage("Title é um campo obrigatório");
            RuleFor(p => p.Title).MaximumLength(100).WithMessage("Title deve ter no máximo 100 caracteres");
            RuleFor(p => p.AcquisitionDate).Must((a, b) => a.AcquisitionDate <= now).WithMessage("A data de aquisição deve ser menor que a data atual");
        }
    }
}
