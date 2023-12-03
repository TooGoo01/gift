namespace Letter.Business.Dtos.Get.Main.Front
{
    public class GetFooterSideDto
    {
        public int Id { get; set; }
        ICollection<GetHomeTypeDto> Types { get; set; }
        ICollection<GetCityDto> Cities { get; set; }
    }
}
