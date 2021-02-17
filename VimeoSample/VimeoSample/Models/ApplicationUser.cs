using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VimeoSample.Models
{
    public class ApplicationUser : IdentityUser
    {
        public long ClipIdUser { get; set; }
    }
}
