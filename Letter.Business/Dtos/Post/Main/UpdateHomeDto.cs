using Microsoft.AspNetCore.Http;

namespace Letter.Business.Dtos.Post.Main
{
    public class UpdateHomeDto
    {
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public string MapAdrress { get; set; }
        public string AzAddress { get; set; }
        public string EnAddress { get; set; }
        public string RuAddress { get; set; }

        //public bool? IsActive { get; set; }
        public int? CityId { get; set; }
        public int? TypeId { get; set; }
        public int? StatusId { get; set; }
        public int? TimeTypeId { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
