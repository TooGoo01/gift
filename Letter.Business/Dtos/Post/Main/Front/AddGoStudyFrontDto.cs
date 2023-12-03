using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Dtos.Post.Main.Front
{
    public class AddGoStudyFrontDto
    {
        public IFormFileCollection Files { get; set; }
    }
}
