using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

public interface IContext
{
    public void Connect(string path, IFileSystem fileSystem);
    public void Disconnect();
    public void TreeGoto(string path);
    public void FileCopy(string sourcePath, string destinationPath);
    public void FileDelete(string path);
    public void FileMove(string sourcePath, string destinationPath);
    public void FileRename(string path, string name);
    public string FileShow(string path, IWriter writer);
    public string TreeList(int depth, IWriter writer);
}