using Letter.DataAccess.Models;

namespace Letter.Business.Dtos.Get.Main
{
    public class AddHomeViewModel
    {
        public IEnumerable<GetCityDto>? Cities { get; set; }
        public IEnumerable<GetHomeTypeDto>? Types { get; set; }
        public IEnumerable<GetTimeTypeDto>? TimeTypes { get; set; }
        public IEnumerable<GetStatusDto>? Statuses { get; set; }
        public UserSessionDto? User { get; set; }
    }
}
