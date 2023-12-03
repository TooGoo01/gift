using AutoMapper;
using Letter.Business.Dtos.Get.Main;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Letter.DataAccess.UnitOfWorks;
using Microsoft.IdentityModel.Tokens;

namespace Letter.Business.Services.Implementations.Main
{
    public class StudentWordsService : IStudentWordsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStudentWordsRepository _studentWordsRepository;
        public StudentWordsService(IUnitOfWork unitOfWork, IMapper mapper, IStudentWordsRepository studentWordsRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _studentWordsRepository = studentWordsRepository;
        }
        public async Task<ServiceResult> AddStudentWords(AddStudentWordsDto studentWords)
        {
            var request = _mapper.Map<StudentWords>(studentWords);
            request.IsActive = true;
            await _unitOfWork.Repository<StudentWords>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetStudentWordsDto>(request);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> DeleteStudentWords(int id)
        {
            var studentWord = await _studentWordsRepository.GetStudentWords(id);
            if (studentWord != null)
            {
                studentWord.IsActive = false;

                _unitOfWork.Repository<StudentWords>().Update(studentWord);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetStudentWordsDto>(studentWord);

                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetActiveStudentWords()
        {
            var studentWords = await _studentWordsRepository.GetActiveStudentWords();
            var response = _mapper.Map<List<GetStudentWordsDto>>(studentWords);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetAllStudentWords()
        {
            var studentWords = await _studentWordsRepository.GetAllStudentWords();
            var response = _mapper.Map<List<GetStudentWordsDto>>(studentWords);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetStudentWords(int id)
        {
            var studentWords = await _studentWordsRepository.GetStudentWords(id);
            var response = _mapper.Map<GetStudentWordsDto>(studentWords);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetStudentWordsByCountryId(int countryId)
        {
            var studentWords = await _studentWordsRepository.GetStudentWordsByCountry(countryId);
            var response = _mapper.Map<List<GetStudentWordsDto>>(studentWords);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> UpdateStudentWords(AddStudentWordsDto studentWords, int id)
        {
            var studentWord = await _studentWordsRepository.GetStudentWords(id);
            if (studentWord != null)
            {


                if (studentWords.CountryId.HasValue)
                {
                    studentWord.CountryId = studentWords.CountryId.Value;
                }

                if (!studentWords.AzName.IsNullOrEmpty())
                {
                    studentWord.AzName = studentWords.AzName;
                } 
                if (!studentWords.EnName.IsNullOrEmpty())
                {
                    studentWord.EnName = studentWords.EnName;
                }
                if (!studentWords.RuName.IsNullOrEmpty())
                {
                    studentWord.RuName = studentWords.RuName;
                }
                if (!studentWords.AzDescription.IsNullOrEmpty())
                {
                    studentWord.AzDescription = studentWords.AzDescription;
                }  
                if (!studentWords.EnDescription.IsNullOrEmpty())
                {
                    studentWord.EnDescription = studentWords.EnDescription;
                } 
                if (!studentWords.RuDescription.IsNullOrEmpty())
                {
                    studentWord.RuDescription = studentWords.RuDescription;
                }
                _unitOfWork.Repository<StudentWords>().Update(studentWord);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetStudentWordsDto>(studentWord);

                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }
    }
}
