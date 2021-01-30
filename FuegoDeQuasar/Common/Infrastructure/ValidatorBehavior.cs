// <copyright file="ValidatorBehavior.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Common.Infrastructure
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    /// <summary>
    /// Validator Behavior.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">Action Result.</typeparam>
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="validators">The validators.</param>
        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        /// <inheritdoc/>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var modelState = new ModelStateDictionary();
            foreach (var validator in this.validators)
            {
                var result = await validator.ValidateAsync(request).ConfigureAwait(false);
                result.AddToModelState(modelState, null);
            }

            if (modelState.IsValid)
            {
                return await next().ConfigureAwait(false);
            }

            return (TResponse)(IActionResult)new BadRequestObjectResult(new ValidationProblemDetails(modelState));
        }
    }
}
