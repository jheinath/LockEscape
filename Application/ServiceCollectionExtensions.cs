﻿using Application.Commands;
using Application.Ports;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            .AddTransient<IEscapeGameDtoConversionService, EscapeGameDtoConversionService>()
            .AddTransient<ICreateGameCommand, CreateGameCommand>()
            .AddTransient<ISelectGroupCommand, SelectGroupCommand>();
    }
}