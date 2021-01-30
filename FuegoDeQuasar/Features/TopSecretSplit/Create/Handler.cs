// <copyright file="Handler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit.Create
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FuegoDeQuasar.Common.Infrastructure;
    using FuegoDeQuasar.Domain.Satellites;
    using FuegoDeQuasar.Features.TopSecretSplit.Models;
    using FuegoDeQuasar.Persistance;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// TopSecret Split create handler.
    /// </summary>
    public class Handler : IRequestHandler<CommandRequest, IActionResult>
    {
        private readonly IMapper mapper;
        private readonly SatelliteContext satelliteContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Handler"/> class.
        /// </summary>
        /// <param name="satelliteContext">Injected satellite context.</param>
        /// <param name="mapper">Injected auto mapper.</param>
        public Handler(SatelliteContext satelliteContext, IMapper mapper)
        {
            this.satelliteContext = satelliteContext;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IActionResult> Handle(CommandRequest request, CancellationToken cancellationToken)
        {
            var satellite = this.satelliteContext.Satellites.FirstOrDefault(s => s.Name == request.Satellite.Name);

            if (satellite == null)
            {
                Satellite newSatellite = this.mapper.Map<WriteModel, Satellite>(request.Satellite);

                this.satelliteContext.Satellites.Add(newSatellite);

                await this.satelliteContext.SaveChangesAsync();

                return this.Ok();
            }

            return this.BadRequest(TopSecretSplitErrors.AlreadySent);
        }
    }
}
