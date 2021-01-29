// <copyright file="TopSecretSplitErrors.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FuegoDeQuasar.Common.Infrastructure;

    /// <summary>
    /// TopSecretSplit errors.
    /// </summary>
    public class TopSecretSplitErrors
    {
        /// <summary>
        /// Gets information already sent error.
        /// </summary>
        public static ApiError AlreadySent => new ApiError(1, "This information has already sent.");

        /// <summary>
        /// Gets name empty error.
        /// </summary>
        public static ApiError NameEmpty => new ApiError(2, "The name could not be empty.");

        /// <summary>
        /// Gets positive distance error.
        /// </summary>
        public static ApiError PositiveDistance => new ApiError(3, "The distance must be a positive number.");

        /// <summary>
        /// Gets message empty error.
        /// </summary>
        public static ApiError MessageEmpty => new ApiError(4, "Must provide message list.");

        /// <summary>
        /// Gets not enough information error.
        /// </summary>
        public static ApiError NotEnoughInformation => new ApiError(5, "There is not enough information.");
    }
}
