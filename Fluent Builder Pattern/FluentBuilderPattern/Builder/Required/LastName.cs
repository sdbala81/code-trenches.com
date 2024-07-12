namespace FluentBuilderPattern.Builder.Required;

public class LastName
{
    private readonly CustomerBuilder _builder;
    private readonly string _firstName;

    public LastName(string firstName)
    {
        _firstName = firstName;
    }

    public BirthYear WithLastName(string lastName)
    {
        return new BirthYear(_firstName, lastName);
    }
}