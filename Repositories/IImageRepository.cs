using Image_Gallery.Models.ImageGallary;
using Microsoft.AspNetCore.Mvc;

namespace Image_Gallery.Repositories
{
    public interface IImageRepository
    {
        void InsertImage(ImageVM images);
        void UpdateImage(ImageVM images);
        void DeleteImage(ImageVM images);
        string GetImageUrl(string id);
        ImageModel GetImage(string id);
        IActionResult GetImages();
        void Save();


    }
}
