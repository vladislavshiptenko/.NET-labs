using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageSendTests
{
    [Fact]
    public void UserReceiveUnreadMessage()
    {
        // Arrange
        IUser user = new User(new List<PairMessageStatus>());
        IAddressee addresseeUser = new AddresseePriorityChecker(new AddresseeUser(user), MessagePriority.Low);
        ITopic topic = new Topic(addresseeUser, "TestTopic");
        var message = new Message("Greetings", "Hello, user!", MessagePriority.Medium);

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.Equal(MessageStatus.Unread, user.GetMessageStatus(message));
    }

    [Fact]
    public void UserReceiveMessageAndMarkAsRead()
    {
        // Arrange
        IUser user = new User(new List<PairMessageStatus>());
        IAddressee addresseeUser = new AddresseePriorityChecker(new AddresseeUser(user), MessagePriority.Low);
        ITopic topic = new Topic(addresseeUser, "TestTopic");
        var message = new Message("Greetings", "Hello, user!", MessagePriority.Medium);

        // Act
        topic.SendMessage(message);
        user.MarkAsRead(message);

        // Assert
        Assert.Equal(MessageStatus.Read, user.GetMessageStatus(message));
    }

    [Fact]
    public void UserReceiveMessageAndMarkAsReadTwice()
    {
        // Arrange
        IUser user = new User(new List<PairMessageStatus>());
        IAddressee addresseeUser = new AddresseePriorityChecker(new AddresseeUser(user), MessagePriority.Low);
        ITopic topic = new Topic(addresseeUser, "TestTopic");
        var message = new Message("Greetings", "Hello, user!", MessagePriority.Medium);

        // Act
        topic.SendMessage(message);
        user.MarkAsRead(message);

        // Assert
        Assert.Throws<ReadMessageMarkAsReadException>(() => user.MarkAsRead(message));
    }

    [Fact]
    public void AddresseNotReceiveLowPriorityMessage()
    {
        // Arrange
        IAddressee addressee = Substitute.For<IAddressee>();
        var priorityChecker = new AddresseePriorityChecker(addressee, MessagePriority.High);
        ITopic topic = new Topic(priorityChecker, "TestTopic");
        var message = new Message("Greetings", "Hello, user!", MessagePriority.Medium);

        // Act
        topic.SendMessage(message);

        // Assert
        addressee.DidNotReceive().SendMessage(message);
    }

    [Fact]
    public void AddresseWriteLog()
    {
        // Arrange
        ILogger logger = Substitute.For<ILogger>();
        var addreseeLogger = new AddresseeLogger(new AddresseeUser(new User(new List<PairMessageStatus>())), logger);
        ITopic topic = new Topic(addreseeLogger, "TestTopic");
        var message = new Message("Greetings", "Hello, user!", MessagePriority.Medium);

        // Act
        topic.SendMessage(message);

        // Assert
        logger.Received().Log(Arg.Any<string>());
    }

    [Fact]
    public void MessengerReceivedMessage()
    {
        // Arrange
        IMessenger messenger = Substitute.For<IMessenger>();
        var addreseeMessenger = new AddresseeMessenger(messenger);
        ITopic topic = new Topic(addreseeMessenger, "TestTopic");
        var message = new Message("Greetings", "Hello, user!", MessagePriority.Medium);

        // Act
        topic.SendMessage(message);

        // Assert
        messenger.Received().ReceiveMessage(Arg.Any<string>());
    }
}