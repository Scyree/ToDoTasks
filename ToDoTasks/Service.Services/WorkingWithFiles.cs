using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Service.Interfaces;

namespace Service.Services
{
    public class WorkingWithFiles : IWorkingWithFiles
    {
        private readonly IHostingEnvironment _env;

        public WorkingWithFiles(IHostingEnvironment env)
        {
            _env = env;
        }

        public void DeleteFolder(string folder)
        {
            var searchedPath = Path.Combine(_env.WebRootPath, folder);

            if (Directory.Exists(searchedPath))
            {
                Directory.Delete(searchedPath, true);
            }
        }

        public void DeleteFileForGivenId(string folder, Guid value, string fileName)
        {
            var searchedPath = Path.Combine(_env.WebRootPath, folder + "\\" + value + "\\" + fileName);

            if (File.Exists(searchedPath))
            {
                File.Delete(searchedPath);
            }
        }

        public string GetPath(string folder, Guid value)
        {
            return Path.Combine(_env.WebRootPath, folder + "\\" + value);
        }

        public void CopyFile(string folder, Guid value, string taskFile)
        {
            var path = Path.Combine(_env.WebRootPath, "Default\\");
            
            foreach (var file in Directory.GetFiles(path))
            {
                var searchedFile = folder + taskFile;
                
                if (Path.GetFileNameWithoutExtension(file) == searchedFile)
                {
                    var targetPath = Path.Combine(_env.WebRootPath, folder + "\\" + value);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    targetPath = Path.Combine(targetPath, Path.GetFileName(file));
                    File.Copy(file, targetPath);
                }
            }
        }
    }
}
