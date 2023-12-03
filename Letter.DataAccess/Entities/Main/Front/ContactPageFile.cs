namespace Letter.DataAccess.Entities.Main.Front
{
    public class ContactPageFile : File
    {
        public int Id { get; set; }
        public ContactPage ContactPage { get; set; }
    }
}
