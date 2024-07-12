using FluentBuilderPattern.Builder.Required;

namespace FluentBuilderPattern.Builder;

public class CustomerBuilder
{
    private int _birthYear;
    private string _firstName;
    private string _lastName;


    public static FirstName Create()
    {
        return new FirstName(new CustomerBuilder());
    }
}