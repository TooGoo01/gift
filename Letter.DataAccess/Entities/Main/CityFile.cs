using Letter.Business.Dtos.Get.Main;

namespace Letter.DataAccess.Entities.Main
{
    public class CityFile : File
    {
        public int Id { get; set; }
        public City City { get; set; }
    }
}
