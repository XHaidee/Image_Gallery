using Image_Gallery.Models.ImageGallary;
using Microsoft.EntityFrameworkCore;

namespace Image_Gallery.Data
{
    public class ImageContext : DbContext
    {
        public ImageContext() { }   
        public ImageContext(DbContextOptions<ImageContext> options) : base(options) { }

        public virtual DbSet<ImageModel> Images { get; set; }
    }
}
