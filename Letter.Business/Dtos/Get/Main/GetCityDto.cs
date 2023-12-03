namespace Letter.Business.Dtos.Get.Main
{
    public class GetCityDto
    {
        public int Id { get; set; }

        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }

        public bool IsActive { get; set; }
        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }

        public int HomeCount { get; set; }
       
        public int Population { get; set; }

       

        public List<GetHomeIdNameDto> Homes { get; set; }
        public List<GetPlaceDto> Places { get; set; }
        public List<GetIconDto> Icons { get; set; }
        public List<GetCityFileDto> CityFiles { get; set; }
    }
}