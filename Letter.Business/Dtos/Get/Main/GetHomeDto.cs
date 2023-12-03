      namespace Letter.Business.Dtos.Get.Main
{
    public class GetHomeDto
    {
        public int Id { get; set; }
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }

        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }

        public string MapAdrress { get; set; }
        public string AzAddress { get; set; }
        public string EnAddress { get; set; }
        public string RuAddress { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public GetCityIdNameDto City { get; set; }
        public List<GetHomeFileDto>  HomeFiles { get; set; }
        public GetHomeTypeIdNameDto Type { get; set; }
        public GetHomeTypeIdNameDto TimeType { get; set; }
        public GetStatusIdNameDto Status { get; set; }
       
    }
}
