using Letter.Business.Dtos.Get.Main;
using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main
{
    public class StudentRequest : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string WhatsAppPhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime? ConsultationDate { get; set; }
        public bool? IsOnline { get; set; }
        public bool IsActive { get; set; }
        public bool Seen { get; set; }
        //public int YourContryId { get; set; }
        //public Country YourContry { get; set; }
        public string YourCountry { get; set; }
        public ICollection<City> Countries { get; set; }
        public ICollection<Direction> Directions { get; set; }
    }
}
