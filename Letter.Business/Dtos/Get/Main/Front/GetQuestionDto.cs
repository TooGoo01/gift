namespace Letter.Business.Dtos.Get.Main.Front
{
    public class GetQuestionDto
    {
        public int Id { get; set; }

        public string AzQuestionTitle { get; set; }
        public string EnQuestionTitle { get; set; }
        public string RuQuestionTitle { get; set; }

        public string AzQuestionAnswer { get; set; }
        public string EnQuestionAnswer { get; set; }
        public string RuQuestionAnswer { get; set; }
    }
}
