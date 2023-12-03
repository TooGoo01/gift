namespace Letter.Business.Dtos.Get.Main.Front
{
    public class GetHeaderSideDto
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public ICollection<GetCityDto> Countries { get; set; }
        public ICollection<GetHomeTypeDto> Types { get; set; }
    }
}
