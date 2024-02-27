using Image_Gallery.Models.ImageGallary;
using Image_Gallery.Repositories;
using Image_Gallery.Services;
using Microsoft.AspNetCore.Mvc;

namespace Image_Gallery.Controllers
{
    public class ImageController : Controller
    {
        private readonly IGalleryManager _galleryService;
        private readonly IImageRepository _galleryRepository;
        public ImageController(IGalleryManager galleryManager,IImageRepository imageRepository)
        {
            _galleryService=galleryManager;
            _galleryRepository = imageRepository;
        }
        public IActionResult Index()
        {
            _galleryService.DisplayImages();
            return View();
        }
        [HttpPost]
        public IActionResult InsertImage(ImageVM image)
        {
            try
            {
                _galleryRepository.InsertImage(image);
                _galleryRepository.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public  IActionResult GetImages()
        {
            var images=_galleryRepository.GetImages();
            return Ok(images);
        }
        [HttpPost]
        public IActionResult InputImage(int Id, string selectedImage)
        {
            return RedirectToAction("Index");
        }
    }
}
