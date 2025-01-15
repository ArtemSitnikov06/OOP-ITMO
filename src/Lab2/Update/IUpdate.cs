using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Update;

public interface IUpdate
{
    IChangeResult CanUpdate(User user);
}