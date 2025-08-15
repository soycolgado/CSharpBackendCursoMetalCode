﻿using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators
{
    public class BeerUpdateValidator: AbstractValidator<BeerUpdateDto>
    {
        public BeerUpdateValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("El id es obligatorio");
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe tener entre 2 y 20 caracteres");
            RuleFor(x => x.BrandID).NotNull().WithMessage("La marca es obligatoria");
            RuleFor(x => x.BrandID).GreaterThan(0).WithMessage("La marca debe ser mayor a 0");
            RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage("El alcohol debe ser mayor a 0");
        }

    }
}
