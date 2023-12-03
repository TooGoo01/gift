using Microsoft.AspNetCore.Http;

namespace Letter.Business.Dtos.Post.Main
{
    public class AddAboutDto
    {
        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }
        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string YoutubeLink { get; set; }
        public string TwitterLink { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
