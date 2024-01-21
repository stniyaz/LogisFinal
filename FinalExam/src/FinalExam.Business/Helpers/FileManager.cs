using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Helpers
{
    public static class FileManager
    {
        public static string Save(string root, string folderPath, IFormFile imageFile)
        {
            var newName = imageFile.FileName;
            newName = newName.Length > 64 ? newName.Substring(newName.Length - 64, 64) : newName;
            newName = Guid.NewGuid().ToString() + newName;

            var path = Path.Combine(root, folderPath, newName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }
            return newName;
        }

        public static void Delete(string root, string folderPath, string imageUrl)
        {
            var deletePath = Path.Combine(root, folderPath, imageUrl);
            if (File.Exists(deletePath))
            {
                File.Delete(deletePath);
            }
        }
    }
}
