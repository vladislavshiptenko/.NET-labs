using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Traverse;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private readonly IFileSystemTraverse _fileSystemTraverse;

    public LocalFileSystem(IFileSystemTraverse fileSystemTraverse)
    {
        _fileSystemTraverse = fileSystemTraverse;
    }

    public void FileCopy(string workingDirectory, string sourcePath, string destinationPath)
    {
        File.Copy(Path.Combine(workingDirectory, sourcePath), Path.Combine(workingDirectory, destinationPath));
    }

    public void FileDelete(string workingDirectory, string path)
    {
        File.Delete(Path.Combine(workingDirectory, path));
    }

    public void FileMove(string workingDirectory, string sourcePath, string destinationPath)
    {
        File.Move(Path.Combine(workingDirectory, sourcePath), Path.Combine(workingDirectory, destinationPath));
    }

    public void FileRename(string workingDirectory, string path, string name)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        int filenameIndex = path.LastIndexOf("/", StringComparison.Ordinal);
        string pathWithoutFilename = path.Substring(0, filenameIndex + 1);
        File.Move(Path.Combine(workingDirectory, path), Path.Combine(pathWithoutFilename, name));
    }

    public string FileShow(string workingDirectory, string path)
    {
        return File.ReadAllText(Path.Combine(workingDirectory, path));
    }

    public string TreeGoto(string workingDirectory, string path)
    {
        return Path.Combine(workingDirectory, path);
    }

    public string TreeList(string workingDirectory, int depth)
    {
        IFileSystemComponent component = GetTree(workingDirectory, depth);
        component.Accept(_fileSystemTraverse);
        return _fileSystemTraverse.Result;
    }

    private IFileSystemComponent GetTree(string workingDirectory, int depth)
    {
        if (workingDirectory is null)
        {
            throw new ArgumentNullException(nameof(workingDirectory));
        }

        int folderNameIndex = workingDirectory.LastIndexOf("/", StringComparison.Ordinal);
        string folderName = workingDirectory.Substring(folderNameIndex + 1);
        var currentFolder = new Folder(new List<IFileSystemComponent>(), folderName, string.Empty);
        if (depth == 0)
        {
            return currentFolder;
        }

        IList<string> files = Directory.GetFiles(workingDirectory);
        foreach (string file in files)
        {
            currentFolder.AddComponent(new Entities.FileSystem.Components.File(file, string.Empty));
        }

        IList<string> folders = Directory.GetDirectories(workingDirectory);
        foreach (string folder in folders)
        {
            IFileSystemComponent nextFolder = GetTree(Path.Combine(workingDirectory, folder), depth - 1);
            currentFolder.AddComponent(nextFolder);
        }

        return currentFolder;
    }
}