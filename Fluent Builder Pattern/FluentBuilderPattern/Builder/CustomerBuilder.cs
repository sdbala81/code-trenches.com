using FluentBuilderPattern.Models;

namespace FluentBuilderPattern.Builder;

public class CustomerBuilder
{
    private string _firstName;
    private string _lastName;
    private int _birthYear;

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

    public CustomerBuilder BornIn(int birthYear)
    {
        _birthYear = _birthYear;
        return this;
    }

    public Customer Build()
    {
        return new Customer
        {
            FirstName = _firstName,
            LastName = _lastName,
            BirthYear = _birthYear
        };
    }
}