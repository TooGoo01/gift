using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Entities.Main
{
    public class PlaceFile : File
    {
        public int Id { get; set; }
        public Place Places { get; set; }
    }
}
