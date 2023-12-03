namespace Letter.DataAccess.Entities.Main
{
    public class DirectionFile : File
    {
        public int Id { get; set; }
        public Direction Direction { get; set; }
    }
}