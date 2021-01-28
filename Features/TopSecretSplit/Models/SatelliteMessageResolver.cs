// <copyright file="SatelliteMessageResolver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using FuegoDeQuasar.Domain.Satellites;

    /// <summary>
    /// SatelliteMessageResolver.
    /// </summary>
    internal class SatelliteMessageResolver : IValueConverter<Satellite, IList<string>>
    {
        /// <inheritdoc/>
        public IList<string> Convert(Satellite sourceMember, ResolutionContext context)
        {
            IList<Message> messages = sourceMember.Messages;

            return sourceMember.Messages.OrderBy(m => m.Order).Select(m => m.Value).ToList();
        }
    }
}