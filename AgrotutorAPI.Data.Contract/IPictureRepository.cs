using System.Collections.Generic;
using AgrotutorAPI.Domain;

namespace AgrotutorAPI.Data.Contract
{
    public interface IPictureRepository
    {
        bool UploadImages(List<MediaItem> mediaItems);

    }
}
