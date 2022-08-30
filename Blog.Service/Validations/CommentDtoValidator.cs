using Blog.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Validations
{
    public class CommentDtoValidator : AbstractValidator<CommentDto>
    {
        public CommentDtoValidator()
        {
            RuleFor(c => c.CommentText).NotNull().WithMessage("{PropertyName} gereklidir").NotEmpty().WithMessage("{PropertyName} gereklidir");

            RuleFor(c => c.CommentId).NotNull().WithMessage("{PropertyName} gereklidir").NotEmpty().WithMessage("{PropertyName} gereklidir");
        }

    }
}
