using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public class NullFileSystem : IFileSystem
{
    public void FileCopy(string workingDirectory, string sourcePath, string destinationPath)
    {
        throw new NullFileSystemException();
    }

    public void FileDelete(string workingDirectory, string path)
    {
        throw new NullFileSystemException();
    }

    public void FileMove(string workingDirectory, string sourcePath, string destinationPath)
    {
        throw new NullFileSystemException();
    }

    public void FileRename(string workingDirectory, string path, string name)
    {
        throw new NullFileSystemException();
    }

    public string FileShow(string workingDirectory, string path)
    {
        throw new NullFileSystemException();
    }

    public string TreeGoto(string workingDirectory, string path)
    {
        throw new NullFileSystemException();
    }

    public string TreeList(string workingDirectory, int depth)
    {
        throw new NullFileSystemException();
    }
}