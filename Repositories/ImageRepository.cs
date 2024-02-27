using Image_Gallery.Data;
using Image_Gallery.Models.ImageGallary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Image_Gallery.Repositories
{
    public class ImageRepository:IImageRepository
    {
        private readonly ImageContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageRepository(ImageContext context,IWebHostEnvironment webhost) 
        { 
            _context = context;
            _webHostEnvironment = webhost;
        }
        public void InsertImage(ImageVM images)
        {
            try
            {
                string filePath = "";
                if (images.ImageUrl != null)
                {
                    var basePath = _webHostEnvironment.WebRootPath;
                    string uploadsFolder = Path.Combine(basePath, "BlobStorage");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = images.ImageUrl.FileName;

                    //string uniqueFileName = $"{pageSectionContent.Page_id}_{pageSectionContent.Section_id}_{pageSectionContent.DisplayOrder}_{Path.GetFileName(pageSectionContent.Image_url.FileName)}";
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        images.ImageUrl.CopyTo(fileStream);
                    }
                    Console.WriteLine(filePath);
                }
                ImageModel imagesModel = new ImageModel()
                {
                    ImageName = images.ImageUrl.FileName.ToString(),
                    ImageUrl=filePath                    
                };
                _context.Add(imagesModel);
            }
            catch
            {
                Console.WriteLine("Exception occoured");
            }
            
        }
        public void UpdateImage(ImageVM images)
        {

        }
        public void DeleteImage(ImageVM images)
        {

        }
        public string GetImageUrl(string id)
        {
            return "hi";
        }
        public ImageModel GetImage(string id)
        {
            ImageModel model = null;
            return model;
        }
        public IActionResult GetImages()
        {
            List<ImageModel> images = _context.Images.ToList();
            return new JsonResult(images);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
