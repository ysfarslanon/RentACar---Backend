using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var result = newPath(file);
            try
            {
                var sourcePath = Path.GetTempFileName();
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                File.Move(sourcePath, result.newPath);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result.Path2;
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            try
            {
                using (var stream = new FileStream(result.newPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                File.Delete(sourcePath);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result.Path2;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            return new SuccessResult();
        }
       
        public static (string newPath, string Path2) newPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            var uniqueFileName = Guid.NewGuid().ToString("N") + fileExtension;
            string result = $@"{Environment.CurrentDirectory}\Uploads\Images\{uniqueFileName}";
            return (result, $"\\Images\\{uniqueFileName}");
        }
    }
}

