using Microsoft.AspNetCore.Http;

namespace Letter.Business.Dtos.Post.Main
{
    public class AddPartnerDto
    {
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public string? AzDescription { get; set; }
        public string? EnDescription { get; set; }
        public string? RuDescription { get; set; }
        public string Link { get; set; }
        public IFormFileCollection? Files { get; set; }

    }
}
