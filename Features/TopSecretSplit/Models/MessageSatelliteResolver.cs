// <copyright file="MessageSatelliteResolver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit.Models
{
    using System.Collections.Generic;
    using AutoMapper;
    using FuegoDeQuasar.Domain.Satellites;

    /// <summary>
    /// MessageSatelliteResolver.
    /// </summary>
    internal class MessageSatelliteResolver : IValueConverter<IList<string>, IList<Message>>
    {
        /// <inheritdoc/>
        public IList<Message> Convert(IList<string> sourceMember, ResolutionContext context)
        {
            IList<Message> messages = new List<Message>();

            for (int i = 0; i < sourceMember.Count; i++)
            {
                var message = sourceMember[i];

                messages.Add(new Message()
                {
                    Order = i,
                    Value = message,
                });
            }

            return messages;
        }
    }
}