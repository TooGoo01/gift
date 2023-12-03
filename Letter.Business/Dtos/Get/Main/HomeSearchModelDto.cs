 namespace Letter.Business.Dtos.Get.Main
{
    public class HomeSearchModelDto
    {
        public string? HomeName { get; set; }
        public List<int>? CityIds { get; set; }
        public List<int>? TypeIds{ get; set; }
        public List<int>? TimeTypeIds{ get; set; }
    }
}
