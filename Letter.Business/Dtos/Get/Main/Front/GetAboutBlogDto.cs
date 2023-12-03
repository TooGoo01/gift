namespace Letter.Business.Dtos.Get.Main.Front
{
    public class GetAboutBlogDto
    {
        public int Id { get; set; }
        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }

        public ICollection<GetBlogDto> Blogs { get; set; }
    }
}
