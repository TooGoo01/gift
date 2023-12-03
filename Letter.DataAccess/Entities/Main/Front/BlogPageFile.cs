namespace Letter.DataAccess.Entities.Main.Front
{
    public class BlogPageFile : File
    {
        public int Id { get; set; }
        public BlogPage BlogPage { get; set; }
    }
}
