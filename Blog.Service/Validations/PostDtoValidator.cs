using Blog.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Validations
{
    public class PostDtoValidator : AbstractValidator<PostDto>
    {
        public PostDtoValidator()
        {
            RuleFor(p => p.PostTitle).NotNull().WithMessage("{PropertyName} gereklidir").NotEmpty().WithMessage("{PropertyName} gereklidir");

            RuleFor(p => p.PostContent).NotNull().WithMessage("{PropertyName} gereklidir").NotEmpty().WithMessage("{PropertyName} gereklidir");

            RuleFor(p => p.PhotoName).NotNull().WithMessage("{PropertyName} gereklidir").NotEmpty().WithMessage("{PropertyName} gereklidir");
        }
    }
}
