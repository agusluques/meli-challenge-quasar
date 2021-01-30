// <copyright file="IntelligenceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.Common.IntelligenceService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FuegoDeQuasar.Common.Enumerations;
    using FuegoDeQuasar.Common.Models;
    using FuegoDeQuasar.Features.Common.MessageDecoder;
    using FuegoDeQuasar.Features.Common.Triangulator;

    /// <summary>
    /// IntelligenceService implementation.
    /// </summary>
    public class IntelligenceService : IIntelligenceService
    {
        /// <inheritdoc/>
        public Position GetLocation(IList<float> distances)
        {
            Position result = Triangulator.Triangulate(SatellitesPositionEnum.Kenobi, SatellitesPositionEnum.Skywalker, SatellitesPositionEnum.Sato, distances[0], distances[1], distances[2]);

            return result;
        }

        /// <inheritdoc/>
        public string GetMessage(IList<IList<string>> messages)
        {
            var messageLength = MessageDecoder.GetMessageLength(messages);

            MessageDecoder.NormalizeLists(messages, messageLength);

            string result = string.Empty;
            for (int i = 0; i < messageLength; i++)
            {
                foreach (List<string> satelliteMessages in messages)
                {
                    if (!string.IsNullOrWhiteSpace(satelliteMessages[i]))
                    {
                        result += satelliteMessages[i] + " ";
                        break;
                    }
                }
            }

            return result.Trim();
        }
    }
}
