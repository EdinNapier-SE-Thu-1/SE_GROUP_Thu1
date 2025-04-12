using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.IO;
using EnviromentalAgency.ViewModels;
using EnviromentalAgency.Data;
using EnviromentalAgency.Models;
using EnviromentalAgency.Views;

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

		var a = Assembly.GetExecutingAssembly();
		using var stream = a.GetManifestResourceStream("EnviromentalAgency.appsettings.json");
			
		var config = new ConfigurationBuilder()
			.AddJsonStream(stream)
			.Build();
			
		builder.Configuration.AddConfiguration(config);

		var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection");
		builder.Services.AddDbContext<NotesDbContext>(options => options.UseSqlServer(connectionString));

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
