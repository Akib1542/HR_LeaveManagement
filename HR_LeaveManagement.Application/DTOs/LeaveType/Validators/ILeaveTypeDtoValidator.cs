﻿using FluentValidation;
using HR_LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
      
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required!")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters!");

            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .GreaterThan(0).WithMessage("{PropertyName} must be atleast 1!")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}!");
        }
    }
}
