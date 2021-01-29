// <copyright file="AutoMapperProfile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.TopSecretSplit.Models
{
    using AutoMapper;
    using FuegoDeQuasar.Domain.Satellites;

    /// <summary>
    /// Configures Auto mapper mappings.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
        /// </summary>
        public AutoMapperProfile()
        {
            this.CreateMap<Satellite, WriteModel>()
                .ForMember(x => x.Message, o => o.ConvertUsing(new SatelliteMessageResolver(), "Messages"));

            this.CreateMap<WriteModel, Satellite>()
                .ForMember(x => x.Messages, o => o.ConvertUsing(new MessageSatelliteResolver(), "Message"));
        }
    }
}
