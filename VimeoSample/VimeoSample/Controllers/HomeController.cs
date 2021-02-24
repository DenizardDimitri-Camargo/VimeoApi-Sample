using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VimeoSample.Models;
using VimeoDotNet;
using Newtonsoft;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using VimeoDotNet.Net;
using Microsoft.AspNetCore.Identity;
using VimeoSample.Data;
using Microsoft.AspNetCore.Authorization;

namespace VimeoSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //8e631984a554c671698d0f2a49cf2edc
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _applicationDbContext;
        //ApplicationUser applicationUser = new ApplicationUser();

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationUser user, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationDbContext = applicationDbContext;
            //applicationUser = user;
        }
        
        string accessToken = "8e631984a554c671698d0f2a49cf2edc";

        [Authorize]
        public async Task<IActionResult> Index() //video 1: Authorization
        {
            try
            {
                VimeoClient vimeoClient = new VimeoClient(accessToken);
                var authcheck = await vimeoClient.GetAccountInformationAsync();
            }
            catch (Exception e)
            {
                throw new Exception("ERRO: " + e.Message);
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Upload() //HttpPostedFile(.net) == IFormFile
        {
            var files = Request.Form.Files; //Request.File(.net) == Request.Form.Files
            IFormFile file = files[0]; //HttpPostedFileBase(.net) == IFormFile 
            string uploadstatus = "";
            try
            {
                if (file != null)
                {
                    VimeoClient vimeoClient = new VimeoClient(accessToken);
                    var authcheck = await vimeoClient.GetAccountInformationAsync();

                    if (authcheck.Name != null)
                    {
                        IUploadRequest uploadRequest = new UploadRequest();
                        BinaryContent binaryContent = new BinaryContent(file.OpenReadStream(), file.ContentType); //InputStream(.net) == OpenReadStream()

                        long chunksizeLong = 0; //tamanho do pedaço
                        long contentleght = file.Length; //tamanho do arquivo em bytes
                        long temp1 = contentleght / 1024; //tamanho do arquivo em Kilobytes
                        if (temp1 > 1)
                        {
                            chunksizeLong = temp1 / 1024; //tamanho do arquivo em Megabytes
                            chunksizeLong = chunksizeLong / 10;
                            chunksizeLong = chunksizeLong * 1048576; //1048576 bytes(1024 * 1024) = 1 MB
                        }
                        else
                        {
                            chunksizeLong = 1048576; //chunk size equal to 1 MB
                        }

                        int chunksize = unchecked((int)chunksizeLong); //converte de long para int (https://stackoverflow.com/questions/858904/can-i-convert-long-to-int)
                        uploadRequest = await vimeoClient.UploadEntireFileAsync(binaryContent, chunksize, null);
                        uploadstatus = String.Concat("file uploaded ", "https://vimeo.com/", uploadRequest.ClipId.Value.ToString(), "/none");
                        //_applicationDbContext.ApplicationUser = uploadRequest.ClipId.Value;
                        var user = await _userManager.GetUserAsync(User); //obtém Denizard
                        //user.ClipIdUser = uploadRequest.ClipId.Value; // coloco o ClipId no user Denizard

                        
                        user.UploadRequests.Add(new LocalUploadRequest(
                            uploadRequest.ChunkSize,
                            uploadRequest.BytesWritten,
                            uploadRequest.IsVerifiedComplete,
                            uploadRequest.ClipUri,
                            uploadRequest.FileLength,
                            uploadRequest.ClipId,
                            user                            
                        ));

                        _applicationDbContext.SaveChanges(); // salvo as mudanças do user Denizard
                    }

                }
            }
            catch (Exception e)
            {
                uploadstatus = "not uploaded: " + e.Message;
                if (e.InnerException != null)
                {
                    uploadstatus += e.InnerException.Message;
                }
            }
            ViewBag.UploadStatus = uploadstatus;
            return View();
        }

        public async Task<IActionResult> Uploaded()
        {
            var user = await _userManager.GetUserAsync(User);
            var result = _applicationDbContext.localUploadRequests.Where(x => x.ApplicationUser.Id.Equals(user.Id)).ToList();
            
            return View(result);
        }

        public async Task<JsonResult> DeleteVideo(long videoId = 0)
        {
            var deleteStatus = "";

            try
            {
                if (videoId > 0)
                {
                    VimeoClient vimeoClient = new VimeoClient(accessToken);

                    await vimeoClient.DeleteVideoAsync(videoId);

                    deleteStatus = "deleted";
                }
            }
            catch (Exception e)
            {
                deleteStatus = "ERRO: " + e.Message;
            }
            return Json(deleteStatus); /* , jsonrequestbehavior.allowget(.net) */
        }

        public async Task<IActionResult> Videos()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
