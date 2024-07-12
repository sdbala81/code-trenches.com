namespace FluentBuilderPattern.Builder;

public class CustomerBuilder
{
    private string _firstName;
    private string _lastName;
    private string _email;

    public CustomerBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public CustomerBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }

    public CustomerBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public Customer Build()
    {
        return new Customer
        {
            FirstName = _firstName,
            LastName = _lastName,
            Email = _email
        };
    }
}

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}