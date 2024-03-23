using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Writer;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;

public class Context : IContext
{
    private IFileSystem _fileSystem = new NullFileSystem();
    private string _path = string.Empty;
    public void Connect(string path, IFileSystem fileSystem)
    {
        _path = path;
        _fileSystem = fileSystem;
    }

    public void Disconnect()
    {
        _path = string.Empty;
        _fileSystem = new NullFileSystem();
    }

    public void TreeGoto(string path)
    {
        try
        {
            _path = _fileSystem.TreeGoto(_path, path);
        }
        catch (Exception e)
        {
            throw new CommandExecuteException(e.Message);
        }
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        try
        {
            _fileSystem.FileCopy(_path, sourcePath, destinationPath);
        }
        catch (Exception e)
        {
            throw new CommandExecuteException(e.Message);
        }
    }

    public void FileDelete(string path)
    {
        try
        {
            _fileSystem.FileDelete(_path, path);
        }
        catch (Exception e)
        {
            throw new CommandExecuteException(e.Message);
        }
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        try
        {
            _fileSystem.FileMove(_path, sourcePath, destinationPath);
        }
        catch (Exception e)
        {
            throw new CommandExecuteException(e.Message);
        }
    }

    public void FileRename(string path, string name)
    {
        try
        {
            _fileSystem.FileRename(_path, path, name);
        }
        catch (Exception e)
        {
            throw new CommandExecuteException(e.Message);
        }
    }

    public string FileShow(string path, IWriter writer)
    {
        try
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            string file = _fileSystem.FileShow(_path, path);
            writer.WriteLine(file);

            return file;
        }
        catch (Exception e)
        {
            throw new CommandExecuteException(e.Message);
        }
    }

    public string TreeList(int depth, IWriter writer)
    {
        try
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            string tree = _fileSystem.TreeList(_path, depth);
            writer.WriteLine(tree);

            return tree;
        }
        catch (Exception e)
        {
            throw new CommandExecuteException(e.Message);
        }
    }
}