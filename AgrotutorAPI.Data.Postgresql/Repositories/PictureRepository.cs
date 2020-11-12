using System;
using System.Collections.Generic;
using System.IO;
using AgrotutorAPI.Data.Contract;
using AgrotutorAPI.Domain;
using Microsoft.AspNetCore.Hosting;

namespace AgrotutorAPI.Data.Postgresql.Repositories
{



  
    public class PictureRepository : IPictureRepository
    {
        private IHostingEnvironment _env;

        public PictureRepository(IHostingEnvironment env)
        {
            _env = env;
        }
        public bool UploadImages(List<MediaItem> mediaItems)
        {
         var directoryPath=   GetDirectoryPath();
           return SaveImage(directoryPath,mediaItems);
        }
        public string GetDirectoryPath()
        {
            var webRoot = _env.ContentRootPath;
            var pathWithFolderName = Path.Combine(webRoot, "Images");


            if (!Directory.Exists(pathWithFolderName))
            {
                // Try to create the directory.
              Directory.CreateDirectory(pathWithFolderName);
            }
            return pathWithFolderName;
        }

        private bool SaveImage(string pathWithFolderName, List<MediaItem> mediaItems)
        {
            foreach (var item in mediaItems)
            {
                var imagePath = pathWithFolderName +@"\"+ item.Id+ ".png";
                //Save the Byte Array as File.
                byte[] bytes = Convert.FromBase64String(item.DataBase64String);
                File.WriteAllBytes(imagePath, bytes);
                item.Path = imagePath;
            }

            return true;
        }
    }
    }
