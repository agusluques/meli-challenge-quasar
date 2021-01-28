// <copyright file="Message.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Domain.Satellites
{
    /// <summary>
    /// Represents a message in database.
    /// </summary>
    public class Message : Entity
    {
        /// <summary>
        /// Gets or sets the value of the message.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the order of the message.
        /// </summary>
        public int Order { get; set; }
    }
}