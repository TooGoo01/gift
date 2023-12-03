namespace Letter.Business.Dtos.Get.Main
{
    public class GetStudentRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string WhatsAppPhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime? ConsultationDate { get; set; }
        public bool IsOnline { get; set; }
        public bool IsActive { get; set; }
        public bool Seen { get; set; }

        public string YourCountry { get; set; }

        //public GetCountryIdName YourContry { get; set; }
        public ICollection<GetCityIdNameDto> Countries { get; set; }
        public ICollection<GetDirectionIdNameDto> Directions { get; set; }
    }
}
