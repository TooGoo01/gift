namespace Letter.Business.Dtos.Get.Main.Front
{
    public class GetContactPageDto
    {
        public int Id { get; set; }
        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }

        public string AzBody { get; set; }
        public string EnBody { get; set; }
        public string RuBody { get; set; }

        public string Map { get; set; }
        public ICollection<GetContactPageFileDto> Files { get; set; }
    }
}
