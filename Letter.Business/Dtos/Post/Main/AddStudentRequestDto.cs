namespace Letter.Business.Dtos.Post.Main
{
    public class AddStudentRequestDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string WhatsAppPhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime? ConsultationDate { get; set; }
        public bool? IsOnline { get; set; }
        //public int YourContryId { get; set; }
        public string YourCountry { get; set; }
        public List<int>? CountryIds { get; set; }
        public List<int>? DirectionIds { get; set; }
    }
}
