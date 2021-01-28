// <copyright file="Satellite.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Domain.Satellites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a satellite in database.
    /// </summary>
    public class Satellite : Entity
    {
        /// <summary>
        /// Gets or sets the name of the satellite.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the distance of the satellite.
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// Gets or sets the list of messages.
        /// </summary>
        public IList<Message> Messages { get; set; }
    }
}
