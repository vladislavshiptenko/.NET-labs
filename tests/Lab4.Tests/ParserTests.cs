using System.Collections.Generic;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.Traverse;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Writer;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    private readonly IParser _parser;

    public ParserTests()
    {
        IParserCommand parserCommand = new ParserDisconnect();
        parserCommand.AddNext(new FileCopyParser());
        parserCommand.AddNext(new FileDeletePath());
        parserCommand.AddNext(new FileMoveParser());
        parserCommand.AddNext(new FileRenameParser());
        parserCommand.AddNext(new TreeGotoParser());

        IParserFlags treeListFlags = new ParserDepthFlag();
        parserCommand.AddNext(new TreeListParser(treeListFlags));

        IFileShowModeRepository fileShowModeRepository = new FileShowModeRepository(new Dictionary<string, IWriter>());
        fileShowModeRepository.Add("console", new ConsoleWriter());
        IParserFlags fileShowFlags = new ParserFileShowModeFlag(fileShowModeRepository);
        parserCommand.AddNext(new FileShowParser(fileShowFlags));

        IConnectionModeFlagRepository connectionModeFlagRepository = new ConnectionModeFlagRepository(new Dictionary<string, IFileSystem>());
        connectionModeFlagRepository.Add("local", new LocalFileSystem(new FileSystemTraverse(0, "\t", new StringBuilder())));
        IParserFlags connectFlags = new ParserConnectionModeFlag(connectionModeFlagRepository);
        parserCommand.AddNext(new ParserConnect(connectFlags));
        _parser = new Parser(parserCommand);
    }

    [Fact]
    public void ConnectTest()
    {
        // Act
        ICommand command = _parser.Parse("connect / -m local");

        // Assert
        Assert.IsType<ConnectCommand>(command);
    }

    [Fact]
    public void DisconnectTest()
    {
        // Act
        ICommand command = _parser.Parse("disconnect");

        // Assert
        Assert.IsType<DisconnectCommand>(command);
    }

    [Fact]
    public void TreeGotoTest()
    {
        // Act
        ICommand command = _parser.Parse("tree goto /home");

        // Assert
        Assert.IsType<TreeGotoCommand>(command);
        if (command is TreeGotoCommand treeGotoCommand)
        {
            Assert.Equal("/home", treeGotoCommand.Path);
        }
    }

    [Fact]
    public void FileCopyTest()
    {
        // Act
        ICommand command = _parser.Parse("file copy /home/1.txt /home/vladislav/1.txt");

        // Assert
        Assert.IsType<FileCopyCommand>(command);
        if (command is FileCopyCommand fileCopyCommand)
        {
            Assert.Equal("/home/1.txt", fileCopyCommand.SourcePath);
            Assert.Equal("/home/vladislav/1.txt", fileCopyCommand.DestinationPath);
        }
    }

    [Fact]
    public void FileDeleteTest()
    {
        // Act
        ICommand command = _parser.Parse("file delete /home/1.txt");

        // Assert
        Assert.IsType<FileDeleteCommand>(command);
        if (command is FileDeleteCommand fileDeleteCommand)
        {
            Assert.Equal("/home/1.txt", fileDeleteCommand.Path);
        }
    }

    [Fact]
    public void FileMoveTest()
    {
        // Act
        ICommand command = _parser.Parse("file move /home/2.png /home/vladislav/2.png");

        // Assert
        Assert.IsType<FileMoveCommand>(command);
        if (command is FileMoveCommand fileMoveCommand)
        {
            Assert.Equal("/home/2.png", fileMoveCommand.SourcePath);
            Assert.Equal("/home/vladislav/2.png", fileMoveCommand.DestinationPath);
        }
    }

    [Fact]
    public void FileRenameTest()
    {
        // Act
        ICommand command = _parser.Parse("file rename 5.docx 6.docx");

        // Assert
        Assert.IsType<FileRenameCommand>(command);
        if (command is FileRenameCommand fileRenameCommand)
        {
            Assert.Equal("5.docx", fileRenameCommand.Path);
            Assert.Equal("6.docx", fileRenameCommand.Name);
        }
    }

    [Fact]
    public void FileShowTest()
    {
        // Act
        ICommand command = _parser.Parse("file show /home/5.docx -m console");

        // Assert
        Assert.IsType<FileShowCommand>(command);
        if (command is FileShowCommand fileShowCommand)
        {
            Assert.Equal("/home/5.docx", fileShowCommand.Path);
            Assert.IsType<ConsoleWriter>(fileShowCommand.Writer);
        }
    }

    [Fact]
    public void TreeListTest()
    {
        // Act
        ICommand command = _parser.Parse("tree list -d 3");

        // Assert
        Assert.IsType<TreeListCommand>(command);
        if (command is TreeListCommand treeListCommand)
        {
            Assert.Equal(3, treeListCommand.Depth);
        }
    }

    [Fact]
    public void DepthInvalidParamTest()
    {
        // Act, Assert
        Assert.Throws<ParseInvalidTypeException>(() => _parser.Parse("tree list -d lol"));
    }

    [Fact]
    public void NonExistentCommandTest()
    {
        // Act, Assert
        Assert.Throws<ParseArgumentException>(() => _parser.Parse("git status"));
    }
}