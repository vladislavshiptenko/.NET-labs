namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public interface IFileSystem
{
    public void FileCopy(string workingDirectory, string sourcePath, string destinationPath);
    public void FileDelete(string workingDirectory, string path);
    public void FileMove(string workingDirectory, string sourcePath, string destinationPath);
    public void FileRename(string workingDirectory, string path, string name);
    public string FileShow(string workingDirectory, string path);
    public string TreeGoto(string workingDirectory, string path);
    public string TreeList(string workingDirectory, int depth);
}