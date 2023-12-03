using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main
{
    public class About : EntityBase, IEntity
    {
        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }

        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }

        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string YoutubeLink { get; set; }
        public string TwitterLink { get; set; }
        public bool IsActive { get; set; }
        public ICollection<AboutFile> AboutFiles { get; set; }
    }
}
