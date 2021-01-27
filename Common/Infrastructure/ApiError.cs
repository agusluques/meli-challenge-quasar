// <copyright file="ApiError.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Common.Infrastructure
{
    /// <summary>
    /// Common api error.
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiError"/> class.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message.</param>
        public ApiError(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string Message { get; set; }
    }
}
