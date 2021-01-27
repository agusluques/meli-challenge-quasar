// <copyright file="Handler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecret.Create
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FuegoDeQuasar.Common.Enumerations;
    using FuegoDeQuasar.Common.Infrastructure;
    using FuegoDeQuasar.Common.Models;
    using FuegoDeQuasar.Features.Common.IntelligenceService;
    using FuegoDeQuasar.Features.TopSecret.Models;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// TopSecret create handler.
    /// </summary>
    public class Handler : IRequestHandler<CommandRequest, IActionResult>
    {
        private readonly IIntelligenceService intelligenceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Handler"/> class.
        /// </summary>
        /// <param name="intelligenceService">Injected intelligence service.</param>
        public Handler(IIntelligenceService intelligenceService)
        {
            this.intelligenceService = intelligenceService;
        }

        /// <inheritdoc/>
        public async Task<IActionResult> Handle(CommandRequest request, CancellationToken cancellationToken)
        {
            IList<float> distances = new List<float>();
            IList<IList<string>> messages = new List<IList<string>>();

            var kenobiInfo = request.Satellites.FirstOrDefault(x => x.Name.ToLower() == SatellitesEnum.Kenobi.ToLower());
            var skywalkerInfo = request.Satellites.FirstOrDefault(x => x.Name.ToLower() == SatellitesEnum.Skywalker.ToLower());
            var satoInfo = request.Satellites.FirstOrDefault(x => x.Name.ToLower() == SatellitesEnum.Sato.ToLower());

            if (kenobiInfo == null || skywalkerInfo == null || satoInfo == null)
            {
                return this.BadRequest(TopSecretErrors.SatelliteIsMissing);
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

            return this.Ok(response);
        }
    }
}
