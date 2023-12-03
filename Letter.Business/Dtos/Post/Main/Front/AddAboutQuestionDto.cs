namespace Letter.Business.Dtos.Post.Main.Front
{
    public class AddAboutQuestionDto
    {
        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }

        public string AzBody { get; set; }
        public string EnBody { get; set; }
        public string RuBody { get; set; }

        public ICollection<int> QuestionIds { get; set; }
    }
}
