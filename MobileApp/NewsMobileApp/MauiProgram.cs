﻿using Microsoft.Extensions.Logging;
using NewsMobileApp.Data;
using NewsMobileApp.TempServices;
using The49.Maui.BottomSheet;
using NewsMobileApp.ViewsNative;
using ImagesCloudTool;
using NewsMobileApp.ViewModels;

namespace NewsMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBottomSheet()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                    fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");
                    fonts.AddFont("NotoSerif-Bold.ttf", "NotoSerif");
                    fonts.AddFont("MaterialIconsOutlined-Regular.otf", "Material");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<INewsService, NewsService>();
            builder.Services.AddScoped<IImageCloudTool, ImageCloudTool>(_ =>
                new ImageCloudTool("fc0f801a94e39de"));
            builder.Services.AddTransient<SectionsPage>();
            builder.Services.AddTransient<ThrendsPage>();
            builder.Services.AddTransient<ThrendsViewModel>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}