using Letter.Business.Dtos.Get.Main;

namespace Letter.Business.Dtos.Post.Main
{
    public class AddHomeTypeDto
    {
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }

        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public ICollection<Home> Homes { get; set; }

        // public IEnumerable<string> Universities { get; set; }
    }
}
