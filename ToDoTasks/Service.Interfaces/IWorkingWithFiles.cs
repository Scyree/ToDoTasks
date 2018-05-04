using System;

namespace Service.Interfaces
{
    public interface IWorkingWithFiles
    {
        void DeleteFolder(string folder);
        void DeleteFileForGivenId(string folder, Guid value, string fileName);
        string GetPath(string folder, Guid value);
        void CopyFile(string folder, Guid value, string taskFile);
    }
}
