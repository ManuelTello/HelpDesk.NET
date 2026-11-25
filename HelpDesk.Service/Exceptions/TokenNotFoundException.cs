namespace HelpDesk.Service.Exceptions;

public class TokenNotFoundException:HelpDeskException
{
    public TokenNotFoundException()
        :base("NOTFOUND","The token was not found")
    {}
}