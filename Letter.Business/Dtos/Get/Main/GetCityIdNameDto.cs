namespace Letter.Business.Dtos.Get.Main
{
    public class GetCityIdNameDto
    {
        public int Id { get; set; }
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public List<GetCityFileDto> CityFiles { get; set; }
    }
}
