// <copyright file="ReadModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit.Models
{
    using FuegoDeQuasar.Common.Models;

    /// <summary>
    /// ReadModel sender information top secret split.
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