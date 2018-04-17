using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlyboMovie.Common
{
    public static class FileHelper
    {
        public const string ImagePath = "./wwwroot/upload/images/";
        public const string VideoPath = "./wwwroot/upload/videos/";
        public const string RelativeImagePath = "/upload/images/";
        public const string RelativeVideoPath = "/upload/videos/";

        public static string GetFileExtName(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                return null;
            }

            var pos = fileName.LastIndexOf('.');
            return pos > -1 ? fileName.Substring(pos) : null;
        }

        public static string SaveFile(string path, IFormFile file)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var fileExtName = GetFileExtName(file.FileName);
            var newFileName = Guid.NewGuid().ToString() + fileExtName;

            using (var fileStream = File.Create(path + newFileName))
            {
                file.CopyTo(fileStream);
            }
            return newFileName;
        }
    }
}
