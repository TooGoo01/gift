namespace Letter.Business.Dtos.Post.Main.Front
{
    public class AddHeaderSideDto
    {
        public string Phone { get; set; }
        public ICollection<int> CountryIds { get; set; }
        public ICollection<int> ProgramIds { get; set; }
    }
}
