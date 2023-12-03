using Letter.DataAccess.Entities.Main;
using Microsoft.AspNetCore.Http;

namespace Letter.Business.Dtos.Post.Main
{
    public class AddCityDto
    {
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public List<int> iconIds { get; set; }

       
        public int? Population { get; set; }
       
        public IFormFileCollection? Files { get; set; }
    }
}
