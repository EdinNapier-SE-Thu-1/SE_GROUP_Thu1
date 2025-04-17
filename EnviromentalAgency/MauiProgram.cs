using Microsoft.Extensions.Logging;

using EnviromentalAgency.ViewModels;
using EnviromentalAgency.Views;
using Notes.Database.Data;

namespace EnviromentalAgency;

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
			});

		builder.Services.AddDbContext<NotesDbContext>();

		builder.Services.AddSingleton<AllNotesViewModel>();
		builder.Services.AddTransient<NoteViewModel>();

		builder.Services.AddSingleton<AllNotesPage>();
		builder.Services.AddTransient<NotePage>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
