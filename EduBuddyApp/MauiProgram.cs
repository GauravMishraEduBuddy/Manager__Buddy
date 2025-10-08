using EduBuddyApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using Radzen;

namespace EduBuddyApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
                    builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddOptions();          // NEW ⬅ required once
            builder.Services.AddAuthorizationCore(); // NEW ⬅ enables [Authorize]
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped(sp =>
            new HttpClient { BaseAddress = new Uri("https://edubuddyapinew-gtf4fsbjaefbdgbk.centralindia-01.azurewebsites.net/") });
            //new HttpClient { BaseAddress = new Uri("https://localhost:7185/") });

            builder.Services.AddScoped<Services.ISchoolService, Services.SchoolService>();
            builder.Services.AddScoped<Services.IEmployeeService, Services.EmployeeService>();
            builder.Services.AddSingleton<UserState>();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<Services.ITimetableService, Services.TimetableService>(); // Register the new TimetableService
            builder.Services.AddScoped<Services.ISyllabusService, Services.SyllabusService>(); // Register the new SyllabusService
            builder.Services.AddScoped<Services.ISectionService, Services.SectionService>(); // Register the new SectionService
            builder.Services.AddScoped<IStudentAttendanceService, StudentAttendanceService>();
            builder.Services.AddScoped<ISubjectService, SubjectService>();
            builder.Services.AddScoped<ISchoolCalendarEventService, SchoolCalendarEventService>();
            // Inside the CreateMauiApp method, in the service registration section:
            builder.Services.AddScoped<ICircularService, CircularService>();
            builder.Services.AddScoped<IPeriodEntryService, PeriodEntryService>();
            // Register the new BooksChapterService
            builder.Services.AddScoped<IBooksChapterService, BooksChapterService>();
            builder.Services.AddScoped<IExamMarksService, ExamMarksService>();
            // Add this line along with the other service registrations
            builder.Services.AddScoped<IOpenAIService, OpenAIService>();
            //BlobStorageService
            //GetFacilitiesStatusAsync
            builder.Services.AddScoped<IFacilityService, FacilityService>();
            builder.Services.AddSyncfusionBlazor();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JEaF5cXmRCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXhedHRXRmBYUEBwWUZWYEk=");


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
