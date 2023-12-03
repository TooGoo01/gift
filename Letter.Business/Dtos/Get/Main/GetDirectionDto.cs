namespace Letter.Business.Dtos.Get.Main
{
    public class GetDirectionDto
    {
        public int Id { get; set; }
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<GetDirectionFileDto> DirectionFiles { get; set; }
        public IEnumerable<GetSpecialityIdNameDto> Specialities { get; set; }
    }
}
