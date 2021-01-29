// <copyright file="ValidatorCollection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit.Create
{
    using FluentValidation;

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
            this.RuleFor(t => t.Satellite.Name)
                .NotEmpty()
                .WithMessage(TopSecretSplitErrors.NameEmpty.Message);

            this.RuleFor(t => t.Satellite.Distance)
                .GreaterThan(0)
                .WithMessage(TopSecretSplitErrors.PositiveDistance.Message);

            this.RuleFor(t => t.Satellite.Message)
                .NotEmpty()
                .WithMessage(TopSecretSplitErrors.MessageEmpty.Message);
        }
    }
}
