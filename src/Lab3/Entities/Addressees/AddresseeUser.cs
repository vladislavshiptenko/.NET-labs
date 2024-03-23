using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeUser : IAddressee
{
    private readonly IUser _user;

    public AddresseeUser(IUser user)
    {
        _user = user;
    }

    public void SendMessage(Message message)
    {
        _user.ReceiveMessage(message);
    }
}