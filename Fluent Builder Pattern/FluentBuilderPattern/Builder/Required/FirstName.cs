namespace FluentBuilderPattern.Builder.Required;

public class FirstName
{
    private readonly CustomerBuilder _builder;

    public FirstName(CustomerBuilder builder)
    {
        _builder = builder;
    }

    public LastName WithFirstName(string firstName)
    {
        return new LastName(firstName);
    }
}