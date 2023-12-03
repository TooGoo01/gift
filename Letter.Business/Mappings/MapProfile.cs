using AutoMapper;
using Letter.Business.Dtos.Get.Libraries;
using Letter.Business.Dtos.Get.Main;
using Letter.Business.Dtos.Get.Main.Front;
using Letter.Business.Dtos.Get.Users;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Dtos.Post.Main.Front;
using Letter.Business.Dtos.Post.Users;
using Letter.DataAccess.Entities.Libraries;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Entities.Users;
using Letter.DataAccess.Models;

namespace Letter.Business.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Blog
            CreateMap<Blog, AddBlogDto>().ReverseMap();
            CreateMap<Blog, GetBlogDto>().ReverseMap();
            CreateMap<Blog, GetBlogFilelessDto>().ReverseMap();
            CreateMap<BlogFile, GetBlogFileDto>().ReverseMap();
            #endregion

            #region About
            CreateMap<About, AddAboutDto>().ReverseMap();
            CreateMap<About, GetAboutDto>().ReverseMap();
            CreateMap<AboutFile, GetAboutFileDto>().ReverseMap();
            #endregion

            #region Direction
            CreateMap<Direction, AddDirectionDto>().ReverseMap();
            CreateMap<Direction, GetDirectionIdNameDto>().ReverseMap();
            CreateMap<Direction, GetDirectionDto>().ReverseMap();
            CreateMap<DirectionFile, GetDirectionFileDto>().ReverseMap();
            CreateMap<Direction, GetDrectionWithUniversityDto>().ReverseMap();
            #endregion

            #region Contact
            CreateMap<Contact, AddContactDto>().ReverseMap();
            CreateMap<GetContactDto, Contact>().ReverseMap();
            CreateMap<GetPersonalAbout, MainAbout>().ReverseMap();
            #endregion

            #region Duration
            //CreateMap<Duration, AddDurationDto>().ReverseMap();
            //CreateMap<Duration, GetDurationDto>().ReverseMap();
            CreateMap<DurationDate, AddDurationDateDto>().ReverseMap();
            CreateMap<DurationDate, GetDurationDateDto>().ReverseMap();
            #endregion

            #region Attendance

            #endregion

            #region City
            CreateMap<City, AddCityDto>().ReverseMap();
            CreateMap<City, GetCityDto>().ReverseMap();
            CreateMap<City, GetCityIdNameDto>().ReverseMap();
            CreateMap<CityFile, GetCityFileDto>().ReverseMap();
            #endregion
            #region Place
            CreateMap<Place, AddPlaceDto>().ReverseMap();
            CreateMap<Place, GetPlaceDto>().ReverseMap();
            CreateMap<PlaceFile, GetPlaceFileDto>().ReverseMap();
            #endregion
            #region Icon
            CreateMap<Icon, AddIconDto>().ReverseMap();
            CreateMap<Icon, GetIconDto>().ReverseMap();
            #endregion

            #region Partner
            CreateMap<Partner, AddPartnerDto>().ReverseMap();
            CreateMap<Partner, GetPartnerDto>().ReverseMap();
            CreateMap<PartnerFile, GetPartnerFileDto>().ReverseMap();
            #endregion

            #region Program
            //CreateMap<HomeType, AddHomeTypeDto>().ReverseMap();
            //CreateMap<LetterProgram, GetLetterProgramDto>().ReverseMap();
            //CreateMap<LetterProgram, GetLetterProgramIdNameDto>().ReverseMap();
            #endregion

            #region Speciality
            CreateMap<Speciality, AddSpecialityDto>().ReverseMap();
            CreateMap<Speciality, GetSpecialityDto>().ReverseMap();
            CreateMap<Speciality, GetSpecialityIdNameDto>().ReverseMap();
            CreateMap<SpecialitySearchModel, SpecialitySearchModelDto>().ReverseMap();
            CreateMap<Speciality, GetSpecialityWithUniveristyDto>().ReverseMap();
            #endregion
            #region HomeType
            CreateMap<HomeType, AddHomeTypeDto>().ReverseMap();
            CreateMap<HomeType, GetHomeTypeDto>().ReverseMap();
            CreateMap<HomeType, GetHomeTypeIdNameDto>().ReverseMap();
            #endregion

            #region Home
            CreateMap<Home, AddHomeDto>().ReverseMap();
            CreateMap<Home, UpdateHomeDto>().ReverseMap();
            CreateMap<Home, GetHomeDto>().ReverseMap();
            CreateMap<Home, GetHomeIdNameDto>().ReverseMap();
            CreateMap<HomeFile, GetHomeFileDto>().ReverseMap();
            CreateMap<HomeSearchModel, HomeSearchModelDto>().ReverseMap();
            #endregion
            #region TimeType
            CreateMap<TimeType, AddTimeTypeDto>().ReverseMap();
            CreateMap<TimeType, GetTimeTypeDto>().ReverseMap();
            CreateMap<TimeType, GetHomeTypeIdNameDto>().ReverseMap();
            #endregion
            #region StudentRequest
            CreateMap<StudentRequest, GetStudentRequestDto>().ReverseMap();
            CreateMap<AddStudentRequestDto, StudentRequest>().ReverseMap();
            #endregion

            #region Status
            CreateMap<Status, GetStatusDto>().ReverseMap();
            CreateMap<Status, AddStatusDto>().ReverseMap();
            CreateMap<Status, GetStatusIdNameDto>().ReverseMap();
            #endregion

            #region AboutCompany
            CreateMap<AboutCompany, AddAboutCompanyDto>().ReverseMap();
            CreateMap<AboutCompany, GetAboutCompanyDto>().ReverseMap();
            #endregion

            #region Header
            CreateMap<Header, AddHeaderDto>().ReverseMap();
            CreateMap<Header, GetHeaderDto>().ReverseMap();
            #endregion

            #region Front
            CreateMap<Question, AddQuestionDto>().ReverseMap();
            CreateMap<Question, GetQuestionDto>().ReverseMap();

            CreateMap<HomePage, AddHomePageDto>().ReverseMap();
            CreateMap<HomePage, GetHomePageDto>().ReverseMap();

            //CreateMap<HeaderSide, AddHeaderSideDto>().ReverseMap();
            //CreateMap<HeaderSide, GetHeaderSideDto>().ReverseMap();

            CreateMap<FooterSide, AddFooterSideDto>().ReverseMap();
            CreateMap<FooterSide, GetFooterSideDto>().ReverseMap();

            CreateMap<BodySide, AddBodySideDto>().ReverseMap();
            CreateMap<BodySide, GetBodySideDto>().ReverseMap();

            CreateMap<AboutQuestion, AddAboutQuestionDto>().ReverseMap();
            CreateMap<AboutQuestion, GetAboutQuestionDto>().ReverseMap();

            CreateMap<AboutCountry, AddAboutCountryDto>().ReverseMap();
            CreateMap<AboutCountry, GetAboutCountryDto>().ReverseMap();

            CreateMap<AboutBlog, AddAboutBlogDto>().ReverseMap();
            CreateMap<AboutBlog, GetAboutBlogDto>().ReverseMap();

            CreateMap<Content, AddContentDto>().ReverseMap();
            CreateMap<Content, GetContentDto>().ReverseMap();
            CreateMap<ContentFile, GetContentFileDto>().ReverseMap();

            CreateMap<AboutPage, AddAboutPageDto>().ReverseMap();
            CreateMap<AboutPage, GetAboutPageDto>().ReverseMap();//.ConvertUsing(new AboutPageFIleConvertor());
            CreateMap<AboutPageFile, GetAboutPageFileDto>().ReverseMap();

            CreateMap<BlogPage, AddBlogPageDto>().ReverseMap();
            CreateMap<BlogPage, GetBlogPageDto>().ReverseMap();//.ConvertUsing(new BlogPageFileConvertor());
            CreateMap<BlogPageFile, GetBlogPageFileDto>().ReverseMap();

            CreateMap<ContactPage, AddContactPageDto>().ReverseMap();
            CreateMap<ContactPage, GetContactPageDto>().ReverseMap();//.ConvertUsing(new ContactPageFileConvertor());
            CreateMap<ContactPageFile, GetContactPageFileDto>().ReverseMap();
            CreateMap<GoStudyFront, AddGoStudyFrontDto>().ReverseMap();
            CreateMap<GoStudyFront, GetGoStudyFrontDto>().ReverseMap();//.ConvertUsing(new ContactPageFileConvertor());
            CreateMap<GoStudyFile, GetGoStudyFrontFileDto>().ReverseMap();




            CreateMap<CountryFront, AddCountryFrontDto>().ReverseMap();
            CreateMap<CountryFront, GetCountryFrontDto>().ReverseMap();

            CreateMap<PartnerFront, AddPartnerFrontDto>().ReverseMap();
            CreateMap<PartnerFront, GetPartnerFrontDto>().ReverseMap();

            CreateMap<DirectionFront, AddDirectionFrontDto>().ReverseMap();
            CreateMap<DirectionFront, GetDirectionFrontDto>().ReverseMap();

            CreateMap<StudentWordsFront, AddStudentWordsFrontDto>().ReverseMap();
            CreateMap<StudentWordsFront, GetStudentWordsFrontDto>().ReverseMap();


            CreateMap<BlogFront, AddBlogFrontDto>().ReverseMap();
            CreateMap<BlogFront, GetBlogFrontDto>().ReverseMap();
            #endregion

            //#region Chat
            //CreateMap<Message, MessageDto>().ReverseMap();
            //CreateMap<Message, MessageRegDto>().ReverseMap();

            //CreateMap<MessageThread, MessageThreadDto>().ReverseMap();
            //CreateMap<MessageThread, MessageThreadRegDto>().ReverseMap();

            //CreateMap<ThreadMember, ThreadMemberDto>().ReverseMap();
            //CreateMap<ThreadMember, ThreadMemberRegDto>().ReverseMap();
            //#endregion

            //#region Request
            //CreateMap<StudentRequest, AddStudentRequestDto>().ReverseMap();
            //CreateMap<StudentRequest, GetStudentRequestDto>().ReverseMap();
            //#endregion

            #region Library
            CreateMap<ThreadMemberRole, IdValuePairDto>().ReverseMap();
            #endregion

            #region User
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<RegisterUserDto, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginUserDto>().ReverseMap();
            CreateMap<ApplicationUser, UserSessionDto>().ReverseMap();
            CreateMap<LoginUserDto, ApplicationUser>().ReverseMap();
            #endregion
        }
    }
}
