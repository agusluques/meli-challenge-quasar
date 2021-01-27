// <copyright file="HandlerExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Common.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Handler Extensions.
    /// </summary>
    public static class HandlerExtensions
    {
        /// <summary>
        /// Return Ok.
        /// </summary>
        /// <typeparam name="TRequest">Type of request.</typeparam>
        /// <typeparam name="TResponse">Type of response.</typeparam>
        /// <param name="handler">handler.</param>
        /// <returns>Ok.</returns>
        public static IActionResult Ok<TRequest, TResponse>(this IRequestHandler<TRequest, TResponse> handler)
            where TRequest : IRequest<TResponse>
            where TResponse : IActionResult => new OkResult();

        /// <summary>
        /// Return Ok.
        /// </summary>
        /// <typeparam name="TRequest">Type of request.</typeparam>
        /// <typeparam name="TResponse">Type of response.</typeparam>
        /// <param name="handler">handler.</param>
        /// <param name="value">Value.</param>
        /// <returns>Ok.</returns>
        public static IActionResult Ok<TRequest, TResponse>(this IRequestHandler<TRequest, TResponse> handler, object value)
            where TRequest : IRequest<TResponse>
            where TResponse : IActionResult => new OkObjectResult(value);

        /// <summary>
        /// Returns a ProblemDetails result with Api Error Detail.
        /// </summary>
        /// <typeparam name="TRequest">Type of request.</typeparam>
        /// <typeparam name="TResponse">Type of response.</typeparam>
        /// <param name="handler">handler.</param>
        /// <param name="error">Api Error.</param>
        /// <returns>Problem Details.</returns>
        public static IActionResult NotFound<TRequest, TResponse>(this IRequestHandler<TRequest, TResponse> handler, ApiError error)
           where TRequest : IRequest<TResponse>
           where TResponse : IActionResult => new NotFoundObjectResult(error);

        /// <summary>
        /// Returns a Bad Request Status.
        /// </summary>
        /// <typeparam name="TRequest">Type of request.</typeparam>
        /// <typeparam name="TResponse">Type of response.</typeparam>
        /// <param name="handler">handler.</param>
        /// <param name="error">ApiError.</param>
        /// <returns>Problem Details.</returns>
        public static IActionResult BadRequest<TRequest, TResponse>(this IRequestHandler<TRequest, TResponse> handler, ApiError error)
          where TRequest : IRequest<TResponse>
          where TResponse : IActionResult => new BadRequestObjectResult(error);
    }
}
