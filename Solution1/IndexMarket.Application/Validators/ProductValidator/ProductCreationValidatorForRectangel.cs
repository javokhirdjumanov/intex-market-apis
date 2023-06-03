﻿using FluentValidation;
using IndexMarket.Application.DataTransferObject;

namespace IndexMarket.Application.Validators;
public class ProductCreationValidatorForRectangel : AbstractValidator<ProductForCreationDtoRectangel>
{
    public ProductCreationValidatorForRectangel()
    {
        RuleFor(c => c)
            .NotNull()
            .WithMessage("Object not null !");

        RuleFor(c => c.Price)
            .NotEqual(null)
            .WithMessage("Price cannot be null !");

        RuleFor(c => c.Amount)
            .NotEqual(null)
            .WithMessage("Amount cannot be null !");

        RuleFor(c => c.Height)
            .NotEqual(null)
            .WithMessage("Height cannot be null !");

        RuleFor(c => c.Weight)
            .NotEqual(null)
            .WithMessage("Weight cannot be null !");

        RuleFor(c => c.Depth)
            .NotEqual(null)
            .WithMessage("Depth cannot be null !");

        RuleFor(c => c.Category_Id)
            .NotEqual(default(Guid))
            .WithMessage("Category Id cannot default Guid !");

        RuleFor(c => c.Shape_Id)
            .NotEqual(default(Guid))
            .WithMessage("Shape Id cannot default Guid !");
    }
}