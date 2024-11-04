using Domain.Entities;

namespace Application.Images.Handler
{
    public sealed class ImageHandler
    {
        public static List<ImageEntity> _images { get; set; }

        public static List<ImageEntity> GetImagesList()
        {
            if(_images == null)
            {
                _images = new List<ImageEntity>();
            }
            return _images;
        }

        public static void ClearImageList()
        {
            _images = null;
        }


    }
}
