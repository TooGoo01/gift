using Letter.Business.Dtos.Get.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Dtos.Post.Main
{
    public class AddIconDto
    {
        public string IconName { get; set; }
        public bool IsActive { get; set; }
        public int cityId { get; set; }
        public City? City { get; set; }
    }
}
