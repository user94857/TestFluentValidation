using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FluentValidation;
using FVTest.Models;

namespace FVTest.FluentValidation
{
    public class MyObjectValidator : AbstractValidator<MyObject>
    {
        public MyObjectValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .OverridePropertyName("MyObject_Name");

            RuleFor(x => x.SubObjects)
                .SetCollectionValidator(new SubObjectValidator())
                .OverridePropertyName("testing123");
        }
    }
}