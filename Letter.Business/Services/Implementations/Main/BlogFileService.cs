using AutoMapper;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.Business.Services.Abstractions.Storage;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.UnitOfWorks;

namespace Letter.Business.Services.Implementations.Main
{
    public class BlogFileService : IBlogFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorage _storage;
        private readonly IMapper _mapper;

        public BlogFileService(IUnitOfWork unitOfWork, IStorage storage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _storage = storage;
            _mapper = mapper;
        }
        public async Task<ServiceResult> AddRangeAsync(AddBlogDto blogDto, int blogId)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-blog", blogDto.Files);
            var blog = _unitOfWork.Repository<Blog>().Get(x => x.Id == blogId);
            _unitOfWork.Repository<BlogFile>().AddRange(result.Select(x => new BlogFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Blog = blog
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> UpdateRangeAsync(AddBlogDto blogDto, int blogId)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-blog", blogDto.Files);
            var blog = _unitOfWork.Repository<Blog>().Get(x => x.Id == blogId);
            var entity = await _unitOfWork.Repository<BlogFile>().GetAllAsync(x => x.Blog.Id == blogId);
            _unitOfWork.Repository<BlogFile>().DeleteRange(entity);
            _unitOfWork.Repository<BlogFile>().UpdateRange(result.Select(x => new BlogFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Blog = blog
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }
    }
}
