using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using TaskReminder.MVVM.Model;
using TaskReminder.Repository;
using TaskReminder.ViewModel;

namespace TaskReminder
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Fontello-Packs-General.ttf", "FPG");
                });

// #if DEBUG
//     		builder.Logging.AddDebug();
// #endif


            builder.Services.AddSingleton<TaskRepository<Tasks>>();
            return builder.Build();
        }
    }
}
