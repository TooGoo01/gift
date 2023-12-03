using Microsoft.AspNetCore.Http;

namespace Letter.Business.Dtos.Post.Main
{
    public class AddBlogDto
    {
        public string AzTitle { get; set; }
        public string EnTitle { get; set; }
        public string RuTitle { get; set; }

        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }


        public IFormFileCollection Files { get; set; }
    }
}
