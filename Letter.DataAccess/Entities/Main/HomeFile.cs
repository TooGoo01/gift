using Letter.Business.Dtos.Get.Main;

namespace Letter.DataAccess.Entities.Main
{
    public class HomeFile : File
    {
        public int Id { get; set; }
        public Home Home { get; set; }
    }
}
