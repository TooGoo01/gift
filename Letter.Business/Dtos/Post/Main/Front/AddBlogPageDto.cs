using Microsoft.AspNetCore.Http;

namespace Letter.Business.Dtos.Post.Main.Front
{
    public class AddBlogPageDto
    {
        public string AzBlogHeader { get; set; }
        public string EnBlogHeader { get; set; }
        public string RuBlogHeader { get; set; }

        public string AzBlogBody { get; set; }
        public string EnBlogBody { get; set; }
        public string RuBlogBody { get; set; }

        public IFormFileCollection Files { get; set; }
    }
}
