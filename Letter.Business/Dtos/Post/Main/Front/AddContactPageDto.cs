using Microsoft.AspNetCore.Http;

namespace Letter.Business.Dtos.Post.Main.Front
{
    public class AddContactPageDto
    {
        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }

        public string AzBody { get; set; }
        public string EnBody { get; set; }
        public string RuBody { get; set; }

        public string Map { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
