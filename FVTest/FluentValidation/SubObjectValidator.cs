using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FVTest.Models;

namespace FVTest.FluentValidation
{
    public class SubObjectValidator : AbstractValidator<SubObject>
    {
        public SubObjectValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .OverridePropertyName("SubObject_Name");
        }
    }
}