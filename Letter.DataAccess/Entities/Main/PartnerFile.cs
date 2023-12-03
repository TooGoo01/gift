namespace Letter.DataAccess.Entities.Main
{
    public class PartnerFile : File
    {
        public int Id { get; set; }
        public Partner Partner { get; set; }
    }
}