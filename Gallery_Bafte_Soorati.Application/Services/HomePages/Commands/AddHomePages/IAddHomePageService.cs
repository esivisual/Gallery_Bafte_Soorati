using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using Gallery_Bafte_Soorati.Common.Dto;
using Gallery_Bafte_Soorati.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery_Bafte_Soorati.Application.Services.HomePages.AddHomePages
{
    public interface IAddHomePageService
    {
        ResultDto Execute(RequireForHomePage Require);
    }
    
    public class AddHomePageService : IAddHomePageService
    {
        private readonly IStorage Storage;
        private readonly IHostingEnvironment environment;
        public AddHomePageService(IStorage _storage, IHostingEnvironment _environment)
        {
            Storage = _storage;
            environment = _environment;
        }
        public ResultDto Execute(RequireForHomePage Require)
        {
            var UpLoadedFile = UpLoadFile(Require.ImageAddress);

                      
            
            HomePageImage homePage = new HomePageImage
            {
                ImageAddress = UpLoadedFile.ImageAddress,
                ImagePosition  = Require.ImageLocation,
                Refer = Require.ImageLink,
            };

            Storage.HomePageImages.Add(homePage);
            Storage.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "تصویر با موفقیت ثبت گردید.",
            };


        }

        private UpLoadFileDto UpLoadFile(IFormFile file)
        {
            if (file != null)
            {
                string Folder = $@"Images\Sliders\";
                var UpLoededRootFolder = Path.Combine(environment.WebRootPath , Folder);
                if (!Directory.Exists(UpLoededRootFolder))
                {
                    Directory.CreateDirectory(UpLoededRootFolder);
                }
                var FileName = DateTime.Now.Ticks.ToString() + file.FileName ;
                var FilePath = Path.Combine(UpLoededRootFolder + FileName);
                using (var fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return new UpLoadFileDto
                {
                    ImageAddress = Folder + FileName,
                    State = true,
                };
            }
            return null;

            
        }
    }


    public class UpLoadFileDto
    {
        public string ImageAddress { get; set; }
        public bool State { get; set; }
        public int Id { get; set; }
    }
    

    public class RequireForHomePage
    {
        public string ImageLink { get; set; }
        public IFormFile ImageAddress { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}

