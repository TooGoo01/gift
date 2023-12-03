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
    public class Icon : EntityBase, IEntity
    {
        public string IconName { get; set; }
        public bool IsActive { get; set; }   
        
        public ICollection<City>? Cities { get; set; }
    }
}
