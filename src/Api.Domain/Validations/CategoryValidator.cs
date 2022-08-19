using Api.Domain.Entities;
using FluentValidation;

namespace Api.Domain.Validations
{
    public class CategoryValidator : AbstractValidator<CategoryEntity>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Title).NotEmpty().WithMessage("Title é um campo obrigatório");
            RuleFor(c => c.Title).MaximumLength(100).WithMessage("Title deve ter no máximo 100 caracteres");

        }
    }
}
