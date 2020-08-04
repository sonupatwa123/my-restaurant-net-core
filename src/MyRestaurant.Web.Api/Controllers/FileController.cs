//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.IO;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using MyRestaurant.Model.Entities;
//using MyRestaurant.Models.Constants;
//using MyRestaurant.Services.Interfaces;

//namespace MyRestaurant.Web.Api.Controllers
//{
//    [Route("File")]
//    [Authorize]
//    public class FileController : ControllerBase
//    {
//        private IFileService _service;
//       public FileController(IFileService Service)
//        {
//            _service = Service;
//        }

//        [Route("UploadRestrauntLogo")]
//       public async Task<IActionResult> UploadRestuarantLogo()
//        {
//            var response =await UploadFile(WebConfigurationService.AppSettings[CommonConstants.RestaurantLogoKey]);
//            return Ok(response);
//        }
//        [Route("UploadMenuLogo")]
//        public async Task<IActionResult> UploadMenuLogo()
//        {
//            var response =await UploadFile(WebConfigurationService.AppSettings[CommonConstants.MenuLogoKey]);
//            return Ok(response);
//        }

//        [Route("UploadOfferLogo")]
//        public async Task<IActionResult> UploadOfferImager()
//        {
//            var response = await UploadFile(WebConfigurationService.AppSettings[CommonConstants.OfferImageUrlKey]);
//            return Ok(response);
//        }
//        [Route("UploadChefPhoto")]
//        public async Task<IActionResult> UploadChefPhoto() {
//            var response = await UploadFile(WebConfigurationService.AppSettings[CommonConstants.ChefImageUrlKey]);
//            return Ok(response);
//        }
//        private async Task<ResponseModel<List<Model.Models>>> UploadFile(string directory)
//        {
//            ResponseModel<List<Model.Models.FileModel>> response = new ResponseModel<List<FileModel>>();
//            List<FileModel> fileModels = new List<FileModel>();
//            // Check if the request contains multipart/form-data.  
//            //if (!Request.Form.Files.Content.IsMimeMultipartContent())
//            //{
//            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
//            //}
//            //if (!Directory.Exists(HttpContext.Current.Server.MapPath(directory)))
//            //{
//            //    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(directory));
//            //}
//            //var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
//            ////access form data  

//            //NameValueCollection formData = provider.FormData;

//            ////access files  
//            //IList<HttpContent> files = provider.Files;
//            //string filename = String.Empty;
//            //for (var f = 0; f < files.Count; f++)
//            //{
//            //    var fileModel = new FileModel();
//            //    HttpContent file1 = files[f];
//            //    var thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');
//            //    Stream input = await file1.ReadAsStreamAsync();

//            //    string directoryName = String.Empty;
//            //    string URL = String.Empty;
//            //    string ext = Path.GetExtension(thisFileName);
//            //    string tempDocUrl = HttpContext.Current.Server.MapPath(directory);

//            //    filename = Guid.NewGuid() + ext;
//            //    var filePath = Path.Combine(tempDocUrl, filename);

//            //    //Deletion exists file  
//            //    if (File.Exists(filePath))
//            //    {
//            //        File.Delete(filename);
//            //    }

//            //    URL = tempDocUrl + filename;

//            //    //Directory.CreateDirectory(@directoryName);  
//            //    using (Stream file = File.OpenWrite(URL))
//            //    {
//            //        input.CopyTo(file);
//            //        //close file  
//            //        file.Close();
//            //    }
//            //    fileModel.FileName = Request.RequestUri.GetLeftPart(UriPartial.Authority) + directory + filename;
//            //    fileModel.MIMEType= MimeMapping.GetMimeMapping(thisFileName);
//            //    fileModel.FileSize = input.Length;
//            //    fileModels.Add(fileModel);
//            //}
//            //response.IsSuccess = true;
//            //response.SuccessCode = CommonConstants.SuccessCode.FileUploaded;
//            //response = MessageHelper<List<FileModel>>.GetResponse(response);
//            //response.ResponseObject = fileModels;            
//            //return response;
//        }

//        [Route("Delete/{filename}")]
//        public async Task<IActionResult> Delete([FromRoute]string filename)
//        {
//            return Ok();
//        }
//    }
//}
