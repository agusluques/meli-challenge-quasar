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
        /// Gets name empty error.
        /// </summary>
        public static ApiError AlreadySent => new ApiError(1, "This information has already sent.");
    }
}
