namespace Letter.DataAccess.Entities.Main
{
    public class StudentFile : File
    {
        public int Id { get; set; }
        public StudentWords StudentWords { get; set; }
    }
}