using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Dtos.Get.Main.Front
{
    public class GetGoStudyFrontDto
    {
        public int Id { get; set; }
        public List<GetGoStudyFrontFileDto> GoStudyFiles { get; set; }
    }
}
