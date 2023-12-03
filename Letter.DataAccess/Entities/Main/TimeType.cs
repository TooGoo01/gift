using Letter.Business.Dtos.Get.Main;
using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Entities.Main
{
    public class TimeType : EntityBase, IEntity
    {
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Home> Homes { get; set; }
    }
}
