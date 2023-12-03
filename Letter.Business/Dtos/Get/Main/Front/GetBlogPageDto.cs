namespace Letter.Business.Dtos.Get.Main.Front
{
    public class GetBlogPageDto
    {
        public int Id { get; set; }
        public string AzBlogHeader { get; set; }
        public string EnBlogHeader { get; set; }
        public string RuBlogHeader { get; set; }

        public string AzBlogBody { get; set; }
        public string EnBlogBody { get; set; }
        public string RuBlogBody { get; set; }
        public ICollection<GetBlogPageFileDto> Files { get; set; }
    }
}
