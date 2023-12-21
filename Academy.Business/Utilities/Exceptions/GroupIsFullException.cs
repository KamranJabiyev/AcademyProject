namespace Academy.Business.Utilities.Exceptions;

public class GroupIsFullException:Exception
{
    public GroupIsFullException(string message) : base(message) { }
}
