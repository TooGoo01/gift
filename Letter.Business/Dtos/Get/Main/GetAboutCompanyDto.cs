namespace Letter.Business.Dtos.Get.Main
{
    public class GetAboutCompanyDto
    {
        public int Id { get; set; }
        public string? MapAdress { get; set; }

        public string? AzAdress { get; set; }
        public string? EnAdress { get; set; }
        public string? RuAdress { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? WebSite { get; set; }
        public bool IsActive { get; set; }
        public string? InstagramLink { get; set; }
        public string? FacebookLink { get; set; }
        public string? YoutubeLink { get; set; }
        public string? TwitterLink { get; set; }
        public string? LinkedinLink { get; set; }
        public string? TelegramLink { get; set; }
    }
}
