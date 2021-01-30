// <copyright file="ReadModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecret.Models
{
    using FuegoDeQuasar.Common.Models;

    /// <summary>
    /// ReadModel TopSecret.
    /// </summary>
    public class ReadModel
    {
        /// <summary>
        /// Gets or sets the poisition of sender.
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the message from sender.
        /// </summary>
        public string Message { get; set; }
    }
}
