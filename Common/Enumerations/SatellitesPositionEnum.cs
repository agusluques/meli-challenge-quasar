// <copyright file="SatellitesPositionEnum.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Common.Enumerations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FuegoDeQuasar.Common.Models;

    /// <summary>
    /// Enum satellites position.
    /// </summary>
    public static class SatellitesPositionEnum
    {
        /// <summary>
        /// Gets or sets Kenobi position.
        /// </summary>
        public static Position Kenobi { get; set; } = new Position(-500, -200);

        /// <summary>
        /// Gets or sets Skywalker position.
        /// </summary>
        public static Position Skywalker { get; set; } = new Position(100, -100);

        /// <summary>
        /// Gets or sets Sato position.
        /// </summary>
        public static Position Sato { get; set; } = new Position(500, 100);
    }
}
