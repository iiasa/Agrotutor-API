using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgrotutorAPI.Data.Entities;
using AgrotutorAPI.Domain;

namespace AgrotutorAPI.web.Repositories
{
    public interface IPictureRepository
    {
        bool UploadImages(List<MediaItemDto> mediaItems);

    }
}
