using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VimeoDotNet.Models;
//using VimeoDotNet.Models; //Video
//using VimeoDotNet.Net; //uploadRequest

namespace VimeoSample.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public List<LocalVideo> Videos { get; set; } //ClipIdUser 
        public ICollection<LocalUploadRequest> UploadRequests { get; set; } = new List<LocalUploadRequest>(); //ClipIdUser 

        //public List<LocalUploadRequest> UserVideos(string userId)
        //{
        //    return UploadRequests.Where(ur => ur.ApplicationUser.Id == userId).ToList();
        //}

        public List<LocalUploadRequest> UserVideos(string userId)
        {
            return UploadRequests.Where(ur => ur.ApplicationUser.Id.Equals(userId)).ToList();
        }
    }
}
