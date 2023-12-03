using AutoMapper;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.Business.Services.Abstractions.Storage;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.UnitOfWorks;

namespace Letter.Business.Services.Implementations.Main
{
    public class StudentFileService : IStudentFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorage _storage;
        private readonly IMapper _mapper;

        public StudentFileService(IUnitOfWork unitOfWork, IStorage storage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _storage = storage;
            _mapper = mapper;
        }
        public async Task<ServiceResult> AddRangeAsync(AddStudentWordsDto studentWords, int id)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-students", studentWords.Files);
            var studentsWord = _unitOfWork.Repository<StudentWords>().Get(x => x.Id == id);
            _unitOfWork.Repository<StudentFile>().AddRange(result.Select(x => new StudentFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                StudentWords = studentsWord
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> UpdateRangeAsync(AddStudentWordsDto studentWords, int id)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-students", studentWords.Files);

            var studentsWord = _unitOfWork.Repository<StudentWords>().Get(x => x.Id == id);
            var entity = await _unitOfWork.Repository<StudentFile>().GetAllAsync(x => x.StudentWords.Id == id);
            _unitOfWork.Repository<StudentFile>().DeleteRange(entity);
            _unitOfWork.Repository<StudentFile>().UpdateRange(result.Select(x => new StudentFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                StudentWords = studentsWord
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }
    }
}