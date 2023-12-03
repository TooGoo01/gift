namespace Letter.DataAccess.Entities.Main.Front
{
    public class ContentFile : File
    {
        public int Id { get; set; }
        public Content Content { get; set; }
    }
}
