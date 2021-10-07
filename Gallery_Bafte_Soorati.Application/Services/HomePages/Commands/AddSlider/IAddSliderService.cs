using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using Gallery_Bafte_Soorati.Application.Services.HomePages.AddHomePages;
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

namespace Gallery_Bafte_Soorati.Application.Services.HomePages.AddSlider
{
    public interface IAddSliderService
    {
        ResultDto Excute(IFormFile File , string Link);
    }

    public class AddSliderService : IAddSliderService
    {
        private readonly IStorage Storage;
        private readonly IHostingEnvironment environment;
        public AddSliderService(IStorage _Storage, IHostingEnvironment _environment)
        {
            Storage = _Storage;
            environment = _environment;
        }
        public ResultDto Excute(IFormFile File, string Link)
        {
            if (File != null)
            {
                var UpLoadedFile = UpLoadFile(File);
                Slider silder = new Slider
                {
                    ImageAddress = UpLoadedFile.ImageAddress,
                    Refer = Link,
                };
                Storage.Sliders.Add(silder);
                Storage.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "تصویر با موفقیت ثبت گردید.",
                };
            }
            return null;
        }
    

        private UpLoadFileDto UpLoadFile(IFormFile file)
        {
            if (file != null)
            {
                string Folder = $@"Images\HomePage\";
                var UpLoededRootFolder = Path.Combine(environment.WebRootPath, Folder);
                if (!Directory.Exists(UpLoededRootFolder))
                {
                    Directory.CreateDirectory(UpLoededRootFolder);
                }
                var FileName = DateTime.Now.Ticks.ToString() + file.FileName;
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

    
}
