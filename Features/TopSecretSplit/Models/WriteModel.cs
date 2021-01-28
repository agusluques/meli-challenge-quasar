﻿// <copyright file="WriteModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// WriteModel TopSecret Split.
    /// </summary>
    public class WriteModel
    {
        /// <summary>
        /// Gets or sets the satellite name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the distance between satellite and sender.
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// Gets or sets the list of messages.
        /// </summary>
        public IList<string> Message { get; set; }
    }
}
