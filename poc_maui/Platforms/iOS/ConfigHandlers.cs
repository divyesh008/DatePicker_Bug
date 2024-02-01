using System;
using HomeKit;
using poc_maui.Controls;
using poc_maui.Platforms.iOS.Handlers;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ConfigHandlers
	{
        public static MauiAppBuilder UseMyPlugin(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(CustomDatePicker), typeof(CustomDatePickerHandler));
            });
            return builder;
        }
    }
}

