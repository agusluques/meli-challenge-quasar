// <copyright file="ValidatorCollection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecret.Create
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentValidation;
    using FuegoDeQuasar.Common.Enumerations;

    /// <summary>
    /// Validator.
    /// </summary>
    public class ValidatorCollection : AbstractValidator<CommandRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorCollection"/> class.
        /// </summary>
        public ValidatorCollection()
        {
            this.RuleForEach(t => t.Satellites)
                .ChildRules(satellite =>
                {
                    satellite.RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage(TopSecretErrors.NameEmpty.Message);

                    satellite.RuleFor(x => x.Distance)
                    .GreaterThan(0)
                    .WithMessage(TopSecretErrors.NonPositiveDistance.Message);
                });
        }
    }
}
