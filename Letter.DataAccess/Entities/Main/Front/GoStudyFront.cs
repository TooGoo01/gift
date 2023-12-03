using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Entities.Main.Front
{
    public class GoStudyFront : EntityBase, IEntity
    {
        public ICollection<GoStudyFile> GoStudyFiles { get; set; }
    }
}
