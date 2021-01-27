// <copyright file="IIntelligenceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.Common.IntelligenceService
{
    using System.Collections.Generic;
    using FuegoDeQuasar.Common.Models;

    /// <summary>
    /// IntelligenceService interface.
    /// </summary>
    public interface IIntelligenceService
    {
        /// <summary>
        /// Calculates the position of the sender.
        /// Assume that distances will be received in order. (1- Kenobi, 2- Skywalker, 3- Sato).
        /// </summary>
        /// <param name="distances">List of distances from each satellite to sender.</param>
        /// <returns>Sender position.</returns>
        public Position GetLocation(IList<float> distances);

        /// <summary>
        /// Calculates the message from the sender.
        /// </summary>
        /// <param name="messages">List of list of messages from each sattelite.</param>
        /// <returns>Sender message.</returns>
        public string GetMessage(IList<IList<string>> messages);
    }
}
