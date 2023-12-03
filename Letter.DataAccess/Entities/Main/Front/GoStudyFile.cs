using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Entities.Main.Front
{
    public class GoStudyFile : File
    {
        public int Id { get; set; }
        public GoStudyFront Content { get; set; }
    }
}
