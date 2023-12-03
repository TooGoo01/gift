namespace Letter.Business.Dtos.Get.Main.Front
{
    public class GetContentDto
    {
        public int Id { get; set; }

        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }

        public string AzBody { get; set; }
        public string EnBody { get; set; }
        public string RuBody { get; set; }

        public List<GetContentFileDto> ContentFiles { get; set; }
    }
}
