// <copyright file="CommandRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit.Create
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FuegoDeQuasar.Features.TopSecretSplit.Models;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// CommandRequest TopSecret Split.
    /// </summary>
    public class CommandRequest : IRequest<IActionResult>
    {
        /// <summary>
        /// Gets or sets the satellite information.
        /// </summary>
        public WriteModel Satellite { get; set; }
    }
}
