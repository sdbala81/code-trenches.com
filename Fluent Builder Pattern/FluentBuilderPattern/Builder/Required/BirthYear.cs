namespace FluentBuilderPattern.Builder.Required;

public class BirthYear
{
    private readonly string _firstName;
    private readonly string _lastName;
    private int? _birthYear;

    public BirthYear(string firstName, string surname)
    {
        _firstName = firstName;
        _lastName = surname;
    }

    public BirthYear BornIn(int birthYear)
    {
        _birthYear = birthYear;
        return this;
    }

    public Models.Customer Build()
    {
        return new Models.Customer
        {
            FirstName = _firstName,
            LastName = _lastName,
            BirthYear = _birthYear
        };
    }
}