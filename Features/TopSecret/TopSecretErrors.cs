// <copyright file="TopSecretErrors.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecret
{
    using FuegoDeQuasar.Common.Infrastructure;

    /// <summary>
    /// TopSecret errors.
    /// </summary>
    public class TopSecretErrors
    {
        /// <summary>
        /// Gets name empty error.
        /// </summary>
        public static ApiError NameEmpty => new ApiError(1, "Each satellite must include the name.");

        /// <summary>
        /// Gets positive distance error.
        /// </summary>
        public static ApiError NonPositiveDistance => new ApiError(2, "Each satellite must include a positive distance.");

        /// <summary>
        /// Gets satellite missing error.
        /// </summary>
        public static ApiError SatelliteIsMissing => new ApiError(3, "Satellite info is missing.");

        /// <summary>
        /// Gets message empty error.
        /// </summary>
        public static ApiError MessageEmpty => new ApiError(4, "Must provide message list.");
    }
}
