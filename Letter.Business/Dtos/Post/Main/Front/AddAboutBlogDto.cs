namespace Letter.Business.Dtos.Post.Main.Front
{
    public class AddAboutBlogDto
    {
        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }

        public ICollection<int> BlogIds { get; set; }
    }
}
