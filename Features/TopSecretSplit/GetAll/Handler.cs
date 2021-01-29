// <copyright file="Handler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit.GetAll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FuegoDeQuasar.Common.Enumerations;
    using FuegoDeQuasar.Common.Infrastructure;
    using FuegoDeQuasar.Common.Models;
    using FuegoDeQuasar.Domain.Satellites;
    using FuegoDeQuasar.Features.Common.IntelligenceService;
    using FuegoDeQuasar.Features.TopSecretSplit.Models;
    using FuegoDeQuasar.Persistance;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// TopSecret Split getall handler.
    /// </summary>
    public class Handler : IRequestHandler<QueryRequest, IActionResult>
    {
        private readonly IMapper mapper;
        private readonly SatelliteContext satelliteContext;
        private readonly IIntelligenceService intelligenceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Handler"/> class.
        /// </summary>
        /// <param name="satelliteContext">Injected satellite context.</param>
        /// <param name="mapper">Injected auto mapper.</param>
        /// <param name="intelligenceService">Injected intelligence service.</param>
        public Handler(SatelliteContext satelliteContext, IMapper mapper, IIntelligenceService intelligenceService)
        {
            this.satelliteContext = satelliteContext;
            this.mapper = mapper;
            this.intelligenceService = intelligenceService;
        }

        /// <inheritdoc/>
        public async Task<IActionResult> Handle(QueryRequest request, CancellationToken cancellationToken)
        {
            IList<float> distances = new List<float>();
            IList<IList<string>> messages = new List<IList<string>>();

            WriteModel kenobiInfo = this.mapper.Map<Satellite, WriteModel>(
                await this.satelliteContext.Satellites
                .Include(s => s.Messages)
                .FirstOrDefaultAsync(x => x.Name.ToLower() == SatellitesEnum.Kenobi.ToLower()));

            WriteModel skywalkerInfo = this.mapper.Map<Satellite, WriteModel>(
                await this.satelliteContext.Satellites
                .Include(s => s.Messages)
                .FirstOrDefaultAsync(x => x.Name.ToLower() == SatellitesEnum.Skywalker.ToLower()));

            WriteModel satoInfo = this.mapper.Map<Satellite, WriteModel>(
                await this.satelliteContext.Satellites
                .Include(s => s.Messages)
                .FirstOrDefaultAsync(x => x.Name.ToLower() == SatellitesEnum.Sato.ToLower()));

            if (kenobiInfo == null || skywalkerInfo == null || satoInfo == null)
            {
                return this.BadRequest(TopSecretSplitErrors.NotEnoughInformation);
            }

            // Order matters.
            distances.Add(kenobiInfo.Distance);
            distances.Add(skywalkerInfo.Distance);
            distances.Add(satoInfo.Distance);

            Position senderPosition = this.intelligenceService.GetLocation(distances);

            messages.Add(kenobiInfo.Message);
            messages.Add(skywalkerInfo.Message);
            messages.Add(satoInfo.Message);

            string senderMessage = this.intelligenceService.GetMessage(messages);

            ReadModel response = new ReadModel
            {
                Position = senderPosition,
                Message = senderMessage,
            };

            // just for testing purpose.
            this.satelliteContext.Satellites.RemoveRange(this.satelliteContext.Satellites);
            await this.satelliteContext.SaveChangesAsync();

            return this.Ok(response);
        }
    }
}
