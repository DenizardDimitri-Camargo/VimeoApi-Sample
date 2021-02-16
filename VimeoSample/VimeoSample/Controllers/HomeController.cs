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

namespace VimeoSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //d7bdf445753dfe5978f018cd97ff82d4
        //afc3f4e971b21d2195081b7f4769c3be

        string accessToken = "afc3f4e971b21d2195081b7f4769c3be";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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
