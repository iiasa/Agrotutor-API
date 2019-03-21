using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgrotutorAPI.Domain;

namespace AgrotutorAPI.Data.Contract
{
    public interface IPictureRepository
    {
        bool UploadImages(List<MediaItem> mediaItems);

    }
}
