using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;


namespace Letter.DataAccess.Entities.Main.Front
{
    public class Header : EntityBase, IEntity
    {
        public string AzTitle { get; set; }
        public string EnTitle { get; set; }
        public string Rutitle { get; set; }
        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
    }
}
