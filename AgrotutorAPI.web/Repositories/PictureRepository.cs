﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AgrotutorAPI.Data.Entities;
using AgrotutorAPI.Domain;
using Microsoft.AspNetCore.Hosting;


namespace AgrotutorAPI.web.Repositories
{



  
    public class PictureRepository : IPictureRepository
    {
        private IHostingEnvironment _env;

        public PictureRepository(IHostingEnvironment env)
        {
            _env = env;
        }
        public bool UploadImages(List<MediaItemDto> mediaItems)
        {
         var directoryPath=   GetDirectoryPath();
           return SaveImage(directoryPath,mediaItems);
        }
        public string GetDirectoryPath()
        {
            var webRoot = _env.WebRootPath;
            var pathWithFolderName = System.IO.Path.Combine(webRoot, "Images");


            if (!Directory.Exists(pathWithFolderName))
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(pathWithFolderName);
                if (!Directory.Exists(pathWithFolderName))
                {
                    Directory.CreateDirectory(pathWithFolderName);
                }

               


            }
            return pathWithFolderName;
        }

        private bool SaveImage(string pathWithFolderName, List<MediaItemDto> mediaItems)
        {
            foreach (var item in mediaItems)
            {
                var imagePath = pathWithFolderName + Guid.NewGuid() + ".png";
                //Save the Byte Array as File.

                File.WriteAllBytes(imagePath, item.ImageBytes);
                item.Path = imagePath;
            }

            return true;
        }
    }
    }
