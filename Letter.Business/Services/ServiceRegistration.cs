using Letter.Business.Mappings;
using Letter.Business.Services.Abstractions.Main;
using Letter.Business.Services.Abstractions.Storage;
using Letter.Business.Services.Abstractions.Users;
using Letter.Business.Services.Implementations.Main;
using Letter.Business.Services.Implementations.Storage;
using Letter.Business.Services.Implementations.Users;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.Extensions.DependencyInjection;

namespace Letter.Business.Services;

public static class ServiceRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        //services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<IStorage, FileStorage>();
        //services.AddScoped<IBlogFileService, BlogFileService>();
        //services.AddScoped<IAboutFileService, AboutFileService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IStausService, StatusService>();
        services.AddScoped<IAboutCompanyService, AboutCompanyService>();
        //services.AddScoped<IPersonalAboutService, PersonalAboutService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IIconService, IconService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IHomeTypeService, HomeTypeService>();
        services.AddScoped<ITimeTypeService, TimeTypeService>();
        //services.AddScoped<ISpecialityService, SpecialityService>();
        //services.AddScoped<IStudentRequestService, StudentRequestService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<ICityFileService, CityFileService>();
        services.AddScoped<IHomeService, HomeService>();
        services.AddScoped<IHomeFileService, HomeFileService>();
        services.AddScoped<IPlaceService, PlaceService>();
        services.AddScoped<IPlaceFileService, PlaceFileService>();
        //services.AddScoped<IDirectionService, DirectionService>();
        //services.AddScoped<IDirectionFileService, DirectionFileService>();
        //services.AddScoped<IPartnerService, PartnerService>();
        //services.AddScoped<IPartnerFileService, PartnerFileService>();
        //services.AddScoped<IStudentFileService, StudentFileService>();
        //services.AddScoped<IStudentWordsService, StudentWordsService>();
        //services.AddScoped<IAboutCompanyService, AboutCompanyService>();
        //services.AddScoped<IAttendanceService, AttendanceService>();
        //services.AddScoped<IAttendanceTypeService, AttendanceTypeService>();
        //services.AddScoped<IDurationService, DurationService>();
        //services.AddScoped<IDurationDateService, DurationDateService>();

        //services.AddScoped<IHeaderService, HeaderService>();
        //services.AddScoped<IAboutBlogService, AboutBlogService>();
        //services.AddScoped<IAboutCountryService, AboutCountryService>();
        //services.AddScoped<IAboutQuestionService, AboutQuestionService>();
        //services.AddScoped<IBodySideService, BodySideService>();
        //services.AddScoped<IContentService, ContentService>();
        //services.AddScoped<IContentFileService, ContentFileService>();
        ////services.AddScoped<IFooterSideService, FooterSideService>();
        ////services.AddScoped<IHeaderSideService, HeaderSideService>();
        //services.AddScoped<IHomePageService, HomePageService>();
        //services.AddScoped<IQuestionService, QuestionService>();

        //services.AddScoped<IAboutPageService, AboutPageService>();
        //services.AddScoped<IAboutPageFileService, AboutPageFileService>();
        //services.AddScoped<IBlogPageService, BlogPageService>();
        //services.AddScoped<IBlogPageFileService, BlogPageFileService>();
        //services.AddScoped<IContactPageService, ContactPageService>();
        //services.AddScoped<IContactPageFileService, ContactPageFileService>();


        //services.AddScoped<IPartnerFrontService, PartnerFrontService>();
        //services.AddScoped<IDirectionFrontService, DirectionFrontService>();
        //services.AddScoped<ICountryFrontService, CountryFrontService>();
        //services.AddScoped<IStudentWordsFrontService, StudentWordsFrontService>();
        //services.AddScoped<IBlogFrontService, BlogFrontService>(); 
        //services.AddScoped<IGoStudyFrontService, GoStudyFrontService>();
        //services.AddScoped<IGoStudyFrontFileService, GoStudyFrontFileService>();
        services.AddAutoMapper(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<MapProfile>();
        });
    }
}
