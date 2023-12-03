using Letter.DataAccess.Repositories;
using Letter.DataAccess.Repositories.Abstractions.Chat;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Letter.DataAccess.Repositories.Implementations.Main;
using Letter.DataAccess.Repositories.Implementations.Main.Front;
using Letter.DataAccess.Repositories.Implementions.Chat;
using Letter.DataAccess.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace EstateBe.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            //var cc = Configuration.ConnectionString;


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogFileRepository, BlogFileRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IAboutFileRepository, AboutFileRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryFileRepository, CountryFileRepository>();
            services.AddScoped<IUniversityFileRepository, UniversityFileRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();
           
            services.AddScoped<ITimeTypeRepository, TimeTypeRepository>();
            //services.AddScoped<IDirectionRepository, DirectionRepository>();
            services.AddScoped<IDirectionFileRepository, DirectionFileRepository>();
            services.AddScoped<IHomeTypeRepository, HomeTypeRepository>();
            //services.AddScoped<ISpecialityRepository, SpecialityRepository>();
            services.AddScoped<IStudentRequestRepository, StudentRequestRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<IPartnerFileRepository, PartnerFileRepository>();

            services.AddScoped<IStudentFileRepository, StudentFileRepository>();
            services.AddScoped<IStudentWordsRepository, StudentWordsRepository>();
            services.AddScoped<IAboutCompanyRepository, AboutCompanyRepository>();
            //services.AddScoped<IDurationRepositoy, DurationRepositoy>();
            services.AddScoped<IDurationDateRepository, DurationDateRepository>();
            //services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IAttendanceTypeRepository, AttendanceTypeRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IIconRepository, IConRepository>();


            services.AddScoped<IHeaderRepository, HeaderRepository>();
            services.AddScoped<IAboutBlogRepository, AboutBlogRepository>();
            services.AddScoped<IAboutCountryRepository, AboutCountryRepository>();
            services.AddScoped<IAboutQuestionRepository, AboutQuestionRepository>();
            services.AddScoped<IHomePageRepository, HomePageRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IBodySideRepository, BodySideRepository>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<IContentFileRepository, ContentFileRepository>();
            //services.AddScoped<IFooterSideRepository, FooterSideRepository>();
            //services.AddScoped<IHeaderSideRepository, HeaderSideRepository>();

            services.AddScoped<IAboutPageRepository, AboutPageRepository>();
            services.AddScoped<IBlogPageRepository, BlogPageRepository>();
            services.AddScoped<IContactPageRepository, ContactPageRepository>();

            services.AddScoped<ICountryFrontRepository, CountryFrontRepository>();
            services.AddScoped<IDirectionFrontRepository, DirectionFrontRepository>();
            services.AddScoped<IPartnerFrontRepository, PartnerFrontRepository>();
            services.AddScoped<IStudentWordsFrontRepository, StudentWordsFrontRepository>();
            services.AddScoped<IBlogFrontRepository, BlogFrontRepository>(); 
            services.AddScoped<IGoStudyFrontRepository, GoStudyFrontRepository>();
            services.AddScoped<IGoStudyFrontFileRepository, GoStudyFrontFileRepository>();

            #region Chat
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageThreadRepository, MessageThreadRepository>();
            services.AddScoped<IThreadMemberRepository, ThreadMemberRepository>();
            #endregion
        }
    }
}
