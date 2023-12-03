namespace Letter.DataAccess.Models
{
    public class HomeSearchModel
    {
        public string? HomeName { get; set; }
        public List<int>? CityIds { get; set; }
        public List<int>? TypeIds { get; set; }
        public List<int>? TimeTypeIds { get; set; }
    }
}
