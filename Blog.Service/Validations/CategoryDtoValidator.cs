using Blog.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Validations
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(c => c.CategoryName).NotNull().WithMessage("{PropertyName} gereklidir").NotEmpty().WithMessage("{PropertyName} gereklidir");
        }
    }
}
