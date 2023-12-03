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
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public BlogService(IUnitOfWork unitOfWork, IMapper mapper, IBlogRepository blogRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blogRepository = blogRepository;
        }

        public async Task<ServiceResult> AddBlog(AddBlogDto blog)
        {
            var request = _mapper.Map<Blog>(blog);
            request.IsActive = true;
            await _unitOfWork.Repository<Blog>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetBlogDto>(request);
            return new ServiceResult(true, response.Id);
        }


        public async Task<ServiceResult> UpdateBlog(AddBlogDto blogDto, int id)
        {
            var blog = await _blogRepository.GetBlog(id);
            if (blog != null)
            {
                if (!blogDto.AzTitle.IsNullOrEmpty())
                {
                    blog.AzTitle = blogDto.AzTitle;
                }

                if (!blogDto.EnTitle.IsNullOrEmpty())
                {
                    blog.EnTitle = blogDto.EnTitle;
                }

                if (!blogDto.RuTitle.IsNullOrEmpty())
                {
                    blog.RuTitle = blogDto.RuTitle;
                }

                if (!blogDto.AzDescription.IsNullOrEmpty())
                {
                    blog.AzDescription = blogDto.AzDescription;
                }

                if (!blogDto.EnDescription.IsNullOrEmpty())
                {
                    blog.EnDescription = blogDto.EnDescription;
                }

                if (!blogDto.RuDescription.IsNullOrEmpty())
                {
                    blog.RuDescription = blogDto.RuDescription;
                }
                _unitOfWork.Repository<Blog>().Update(blog);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetBlogDto>(blog);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> DeleteBlogById(int blogId)
        {
            var blog = await _blogRepository.GetBlog(blogId);
            if (blog != null)
            {
                blog.IsActive = false;
                _unitOfWork.Repository<Blog>().Update(blog);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetBlog(int blogId)
        {
            try
            {
                var result = await _blogRepository.GetBlog(blogId);
                if (result == null)
                    return new ServiceResult(false, "data not found");

                var response = _mapper.Map<GetBlogDto>(result);
                return new ServiceResult(true, response);
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<ServiceResult> GetBlogs()
        {
            var blogs = await _blogRepository.GetBlogs();
            if (blogs != null)
            {
                var response = _mapper.Map<ICollection<GetBlogDto>>(blogs);
                return new ServiceResult(true, response);
            }

            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetActiveBlogs()
        {
            var blogs = await _blogRepository.GetActiveBlogs();
            if (blogs != null)
            {
                var response = _mapper.Map<ICollection<GetBlogDto>>(blogs);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetActiveBlogsWithouttFile()
        {
            var blogs = await _blogRepository.GetActiveBlogsWithoutFile();
            if (blogs != null)
            {
                var response = _mapper.Map<ICollection<GetBlogFilelessDto>>(blogs);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }
    }
}
