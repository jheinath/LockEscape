﻿using Adapters.Decoding;
using Application.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IDecodeQrCodesRepository, DecodeQrCodesRepository>();
        return services;
    }
}