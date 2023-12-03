namespace Letter.Business.Dtos.Post.Main
{
    public class AddSpecialityDto
    {
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }

        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public List<int> DirectionIds { get; set; }
    }
}
